using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickTracker : MonoBehaviour
{
    public Vector3 initialVel;
    public Vector3 initialRot;

    private float Force;
    private Joint joint;

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
        //Check relative velocity, if it is different from initial.
        //if (initialVel != (current>0)) { }

        // Is the force growing, or shrinking?
        if (Force < joint.currentForce.magnitude) {
            Force = joint.currentForce.magnitude;
            Debug.Log("Force up");
        } else { // shrinking, time to stop.
                 // break spring
                 // create static joint
            Debug.Log("Force down");
        }
    }

    // Get the collision
    public void setup(Collision collision) {
        // create initial spring. make sure there is good space between them (none)
        var newjoint = gameObject.AddComponent<SpringJoint>();
        newjoint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();

        newjoint.anchor = //Local coords for this object spring point
            collision.GetContact(0).point;
        //    gameObject.transform.InverseTransformPoint( //global to local conversion
        //        Hand.GetComponent<Transform>().position); //Grab point
    }
}
