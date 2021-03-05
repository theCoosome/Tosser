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

    public float PermForce = 1;

    ///1 for positive, 0 for negative
    ///
    // Start is called before the first frame update
    void Start()
    {
        //initialVel = new Vector3((initialVel.x > 0), (initialVel.y > 0), initialVel.z > 0));
        //initialRot = new Vector3((initialRot.x > 0), (initialRot.y > 0), initialRot.z > 0));
        Force = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        return;
        //Check relative velocity, if it is different from initial.
        //if (initialVel != (current>0)) { }
        if (!stuck) {
            // Is the force growing, or shrinking?
            if (Force < joint.currentForce.magnitude) {
                Force = joint.currentForce.magnitude;
                Debug.Log("Force up: " + Force);
            } 
            if (Force * 0.9 > joint.currentForce.magnitude 
                || joint.currentForce.magnitude > PermForce)  // this may not work well for small objects. Force related to mass?
             { // shrinking, time to stop.
                var newjoint = gameObject.AddComponent<FixedJoint>(); // create static joint
                newjoint.connectedBody = joint.connectedBody;
                Destroy(joint);// break spring
                joint = newjoint;
                Debug.Log("Force down: " + Force);
                stuck = true;
            }
        }
    }

    // Get the collision
    public void setup(GameObject collided) {

        Debug.Log("Is anything happening?");
        // create initial spring. make sure there is good space between them (none)

        //joint = gameObject.AddComponent<ConfigurableJoint>();
        //joint.connectedBody = collided.GetComponent<Rigidbody>();

        joint = gameObject.AddComponent<SpringJoint>();
        joint.connectedBody = collided.GetComponent<Rigidbody>();

        //joint.anchor = collision.GetContact(0).point;
        //    gameObject.transform.InverseTransformPoint( //global to local conversion
        //        Hand.GetComponent<Transform>().position); //Grab point

        //joint.spring = 10;
        //joint.damper = 10;
    }
}
