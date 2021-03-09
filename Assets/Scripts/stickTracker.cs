using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickTracker : MonoBehaviour
{
    public Vector3 initialVel;
    public Vector3 initialRot;

    private float Force;
    private Joint joint;
    private bool stuck = false;

    //public float PermForce = 1;
    public float Tracker;

    public WeaponPart HitFrom;

    ///1 for positive, 0 for negative
    ///
    // Start is called before the first frame update
    void Start()
    {
        //initialVel = new Vector3((initialVel.x > 0), (initialVel.y > 0), initialVel.z > 0));
        //initialRot = new Vector3((initialRot.x > 0), (initialRot.y > 0), initialRot.z > 0));
        Force = 0;
        Tracker = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!stuck) {
            float dist = Vector3.Distance(
            //connected anchor transform to world space via connected object
                HitFrom.gameObject.transform.TransformPoint(joint.connectedAnchor),
            //anchor transform to world space via this gameobject
                gameObject.transform.TransformPoint(joint.anchor));
            Debug.Log("Worldspace distance: " + dist);
            if (dist >= Tracker) {
                Tracker = dist;
            }
            else
            { // Stick me
                var newjoint = gameObject.AddComponent<FixedJoint>(); // create static joint
                newjoint.connectedBody = joint.connectedBody;
                Destroy(joint);// break spring
                joint = newjoint;
                Debug.Log("Force down: " + Force);
                stuck = true;
            }
        }

    }


    public void OnTriggerExit(Collider other) {
        if (HitFrom == null) return;
        if (other.gameObject == HitFrom.gameObject) {
            Destroy(joint);
            Destroy(this);
            return;
        }
    }

    // Get the collision
    public void setup(WeaponPart hitfrom, Vector3 modCollide) {
        HitFrom = hitfrom;
        var collided = hitfrom.parent;
        // Don't hook onto the same thing twice (may want to make it only per weapon part instead of rigidbody)
        foreach (stickTracker t in gameObject.GetComponents<stickTracker>()) {
            if (t.joint == null) continue;
            if (t.joint.connectedBody == collided.GetComponent<Rigidbody>()) {
                Destroy(this);
                return;
            }
        }

        //Debug.Log("Is anything happening?");
        // create initial spring. make sure there is good space between them (none)

        var newJoint = gameObject.AddComponent<ConfigurableJoint>();
        newJoint.connectedBody = collided.GetComponent<Rigidbody>();

        //joint = gameObject.AddComponent<SpringJoint>();
        //joint.connectedBody = collided.GetComponent<Rigidbody>();


        //var why = new JointDrive();
        //why.positionSpring = joint.slerpDrive.positionSpring + spinStr * mult;
        //why.maximumForce = joint.slerpDrive.maximumForce;
        //joint.slerpDrive = why;

        newJoint.axis = collided.transform.forward;

        //var limits = new SoftJointLimit();
        //limits.limit = 2000;
        //newJoint.angularYLimit = limits;
        //newJoint.angularZLimit = limits;
        //newJoint.highAngularXLimit = limits;
        //newJoint.lowAngularXLimit = limits;

        // Rotation?
        newJoint.rotationDriveMode = RotationDriveMode.Slerp;
        var joints = new JointDrive();
        joints.positionSpring = 100;
        joints.maximumForce = 100000;
        newJoint.slerpDrive = joints;

        // Position
        var grabs = new JointDrive();
        grabs.maximumForce = 100000;

        if (modCollide.magnitude == 0) { // if no cutting surfaces, "bounce off"
            var limit = new SoftJointLimit();
            limit.bounciness = 1F;
            limit.limit = 0.05F;
            grabs.positionSpring = 0;
            newJoint.linearLimit = limit;
            newJoint.xMotion = ConfigurableJointMotion.Limited;
            newJoint.yMotion = ConfigurableJointMotion.Limited;
            newJoint.zMotion = ConfigurableJointMotion.Limited;
            stuck = true; // skip further sticking
        } else { // Modify to allow more movement along effective vectors
            float Str = 5000;
            grabs.positionDamper = 50 * newJoint.connectedBody.mass;
            grabs.positionSpring = Str * ((1F - modCollide.x)*(1F - modCollide.x) + 0.1F);
            newJoint.xDrive = grabs;
            grabs.positionSpring = Str * ((1F - modCollide.y)*(1F - modCollide.y) + 0.1F);
            newJoint.yDrive = grabs;
            grabs.positionSpring = Str * ((1F - modCollide.z)*(1F - modCollide.z) + 0.1F);
            newJoint.zDrive = grabs;
        }


        newJoint.anchor = //Local coords for this object spring point
            gameObject.transform.InverseTransformPoint( //global to local conversion
                //collided.GetComponent<Rigidbody>().GetComponent<Transform>().position); //Grab point
                hitfrom.gameObject.GetComponent<Collider>().ClosestPointOnBounds(
                    gameObject.transform.position));

        joint = newJoint;

        //joint.anchor = collision.GetContact(0).point;
        //    gameObject.transform.InverseTransformPoint( //global to local conversion
        //        Hand.GetComponent<Transform>().position); //Grab point

        //joint.spring = 10;
        //joint.damper = 10;
    }
}
