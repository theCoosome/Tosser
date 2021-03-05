using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicsObject : MonoBehaviour {

    private const float spinStr = 20;
    private const float grabStr = 1750;

    public byte grabbed = 0;
    public byte dualGrab = 0;

    private GameObject Grabber = null;
    private GameObject Grabber2 = null;

    public static float AxePosx;
    public static float AxePosy;
    public static float AxePosz;

    public static float PencilPosx;
    public static float PencilPosy;
    public static float PencilPosz;

    public static float PinPosx;
    public static float PinPosy;
    public static float PinPosz;

    public GameObject COM;

    public Rigidbody rb;

    // Use this for initialization
    void Start() {
        //Debug.Log(gameObject.name);
        rb = gameObject.GetComponent<Rigidbody>();
        //Debug.Log(rb.centerOfMass);
        var scale = gameObject.GetComponent<Transform>().localScale;
        var pos = COM.GetComponent<Transform>().localPosition;
        rb.centerOfMass = new Vector3(pos[0]*scale[0], pos[1]*scale[1], pos[2]*scale[2]);
        //Debug.Log(rb.centerOfMass);

        if (rb.name == "Axe")
        {
            AxePosx = transform.position.x;
            AxePosy = transform.position.y;
            AxePosz = transform.position.z;
        }
        if (rb.name == "Pencil")
        {
            PencilPosx = transform.position.x;
            PencilPosy = transform.position.y;
            PencilPosz = transform.position.z;
        }
        if (rb.name == "Pin")
        {
            PinPosx = transform.position.x;
            PinPosy = transform.position.y;
            PinPosz = transform.position.z;
        }
    }

    // Update is called once per frame
    void Update() {
        
        if (grabbed > 0) {

            //Debug.Log("Current force:"+ gameObject.GetComponent<SpringJoint>().currentForce.magnitude);
            foreach (ConfigurableJoint j in gameObject.GetComponents<ConfigurableJoint>()) {

                if (j.connectedBody.gameObject == Grabber) {

                    if (j.currentForce.magnitude > 50) { //player strength
                                                         //Destroy(j);
                        Debug.Log("A grip has been broken- Not strong enough");
                    }
                    if (Vector3.Distance(gameObject.transform.TransformPoint(j.anchor), Grabber.transform.position) > 0.08) { // too far
                        Grabber.GetComponent<ControllerGrab>().forceUngrab();
                        release(Grabber);
                        Debug.Log("A grip has been broken- Too far!");
                        //TODO regrab if within grab range
                    }
                    if (j.currentTorque.magnitude > 50) { // too much angle distance?

                        Debug.Log("A grip has been broken- Twisted out!");
                    }
                } else if (j.connectedBody.gameObject == Grabber2) {

                    if (j.currentForce.magnitude > 50) { //player strength
                                                         //Destroy(j);
                        Debug.Log("A grip has been broken- Not strong enough");
                    }
                    if (Vector3.Distance(gameObject.transform.TransformPoint(j.anchor), Grabber2.transform.position) > 0.08) { // too far
                        Grabber2.GetComponent<ControllerGrab>().forceUngrab();
                        release(Grabber2);
                        Debug.Log("A grip has been broken- Too far!");
                        //TODO regrab if within grab range
                    }
                    if (j.currentTorque.magnitude > 50) { // too much angle distance?

                        Debug.Log("A grip has been broken- Twisted out!");
                    }
                }
            }
        }

        //if (hitby ==1 and )

    }

    //track relative pos and angle here?
    public void setGrab(GameObject g, bool regrab) {
        /*if (g == Grabber) {

        } else {
            //Use contacting boxes
            addGripJoint(g.GetComponent<Rigidbody>(), g);
            if (grabbed == 0) {
                Grabber = g;
                grabbed += true;
            } else {
                Grabber2 = g;
                dualGrab = true;
            }
        }*/
        if (Grabber == null) {
            Grabber = g;
            grabbed = 0;
        } else if (g != Grabber) {
            Grabber2 = g;
            dualGrab = 0;
        }

        if (!regrab) {
            //Create a new joint only if you aren't holding it
            addGripJoint(g.GetComponent<Rigidbody>(), g);
        } else {
            if (g == Grabber) {
                grabbed = 0;
            }
            if (g == Grabber2) {
                dualGrab = 0;
            }
            //Move positions on regrab? done below

        }

        //Count grab quantity on object
        foreach (BoxCollider c in g.GetComponents<BoxCollider>()) {
            if (c.bounds.Contains(
                gameObject.GetComponent<Rigidbody>().ClosestPointOnBounds(
                    g.transform.TransformPoint(c.center)))) {
                if (g == Grabber) {
                    grabbed += 1;
                }
                if (g == Grabber2) {
                    dualGrab += 1;
                }
            }
        }


        //TODO BIG CHANGES- count up FROM ZERO for grab forces, reduce overall torque ON BOTH if dual grabbed

        //   TODO   Implement reduced torque when dual grabbed
        //add to the forces on the joint to new grab values. DOESN'T RESET
        foreach (ConfigurableJoint i in gameObject.GetComponents<ConfigurableJoint>()) {
            if (i.connectedBody == g.GetComponent<Rigidbody>()) {
                var mult = (g == Grabber) ? grabbed : dualGrab; //which is which?

                var why = new JointDrive();
                why.positionSpring = i.slerpDrive.positionSpring + spinStr * mult;
                why.maximumForce = i.slerpDrive.maximumForce;
                i.slerpDrive = why;

                if (regrab) {
                    i.anchor = //Local coords for this object spring point
                        gameObject.transform.InverseTransformPoint( //global to local conversion
                            g.GetComponent<Rigidbody>().GetComponent<Transform>().position); //Grab point
                    Debug.Log("Sucesful grip shift");
                }
            }

            if (dualGrab != 0) {
                //can't just devide here bc the other hand can be divided multiple times without reset
            }
        }

        //if dualgrabbed devide force on all by 2? no, taken care of by itself.



        Debug.Log("Attempting Grab...");

    }

    public void release(GameObject g) {
        if (grabbed != 0) {
            foreach (ConfigurableJoint i in gameObject.GetComponents<ConfigurableJoint>()) {
                if (i.connectedBody == g.GetComponent<Rigidbody>()) {

                    //Remove second grab
                    if (g == Grabber2) {
                        dualGrab = 0;
                        Grabber2 = null;
                    }

                    //Remove first grab
                    if (g == Grabber) {
                        grabbed = 0; //-= 1? does it count? or is it 1/0?
                        Grabber = null;

                        //move second grab to first
                        if (dualGrab > 0) {
                            Grabber = Grabber2;
                            grabbed = dualGrab;
                            Grabber2 = null;
                            dualGrab = 0;
                        }
                    }
                    Destroy(i);
                }
            }
        } else {
            Debug.Log("Releasing something that isn't held!");
        }
    }

    private void addGripJoint(Rigidbody ConnectedTo, GameObject Hand) {
        var newJoint = gameObject.AddComponent<ConfigurableJoint>();
        newJoint.anchor = //Local coords for this object spring point
            gameObject.transform.InverseTransformPoint( //global to local conversion
                Hand.GetComponent<Transform>().position); //Grab point

        //newJoint.autoConfigureConnectedAnchor = false;
        //newJoint.connectedAnchor = //Local coords for connected body spring attachment location. 0 is good
        //    new Vector3(0, 0, 0);

        newJoint.connectedBody = ConnectedTo;

        newJoint.angularXMotion = ConfigurableJointMotion.Free;
        newJoint.angularYMotion = ConfigurableJointMotion.Free;
        newJoint.angularZMotion = ConfigurableJointMotion.Free;

        //newJoint.angularXLimitSpring.spring = 50f;

        newJoint.xMotion = ConfigurableJointMotion.Free;
        newJoint.yMotion = ConfigurableJointMotion.Free;
        newJoint.zMotion = ConfigurableJointMotion.Free;

        //newJoint.angularYLimit

        newJoint.rotationDriveMode = RotationDriveMode.Slerp;

        //newJoint.xDrive. = 
        //newJoint.slerpDrive
        var limits = new SoftJointLimit();
        limits.limit = 177;
        newJoint.angularYLimit = limits;
        newJoint.angularZLimit = limits;
        newJoint.highAngularXLimit = limits;
        newJoint.lowAngularXLimit = limits;

        var joints = new JointDrive();
        joints.positionSpring = 10;
        joints.maximumForce = 500;
        newJoint.slerpDrive = joints;

        var grabs = new JointDrive();
        grabs.positionSpring = grabStr;
        grabs.maximumForce = grabStr;
        newJoint.xDrive = grabs;
        newJoint.yDrive = grabs;
        newJoint.zDrive = grabs;

        /*var newJoint = gameObject.AddComponent<SpringJoint>();
        newJoint.connectedBody = ConnectedTo;
        newJoint.spring = 500; //TODO set to use strength
        newJoint.breakForce = 500; //TODO also use strength? or based on item?
        */
    }

    void OnJointBreak(float breakForce) {
        Debug.Log("A grip has been broken TOO FAR! force: " + breakForce);
        //TODO remove related numbers or recalculate Grabber, Grabber2, Dualgrab
        Grabber = null;
        Grabber2 = null;
        grabbed = 0;
        dualGrab = 0;
    }
}
