using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ControllerGrab : MonoBehaviour {



    public SteamVR_Action_Boolean grabAction;
    //public Hand hand;
    public SteamVR_Input_Sources Hand;

    // Currenly colliding object
    public GameObject collidingObject;
    private GameObject collidingFinger;

    // Reference to object currently grabbed
    private GameObject objectInHand;
    private bool grabbed = false;


    private void Start() {
        //hand = this.GetComponent<Hand>();
    }

    private void SetCollidingObject(Collider col) {
        // 1 don't grab the same thing, don't grab ungrabbable (no rigidbody)
        if (!col.GetComponent<Grabbable>()) {
            return;
        }
        // set it as grab target
        
        collidingObject = col.gameObject;
        //Debug.Log("Touch: "+collidingObject.name);
    }

    // Set up potential grab target
    public void OnTriggerEnter(Collider other) {
        SetCollidingObject(other);
    }

    // make sure its still there i guess. try without at some point
    public void OnTriggerStay(Collider other) {
        SetCollidingObject(other);
    }

    // remove potential for grabbing
    public void OnTriggerExit(Collider other) {
        if (!collidingObject) {
            return;
        }
        if (other.gameObject == collidingObject) {
            collidingObject = null;
            //Debug.Log("Left: "+other.gameObject.name);
        }
    }

    public void forceUngrab() {
        objectInHand = null;
        grabbed = false;

    }

    //Time to grab
    private void GrabObject() {

        if (!grabbed) {
            objectInHand = collidingObject;
            collidingObject = null;
        }


        //Debug.Log("Grabbing...");
        if (objectInHand.GetComponent<Grabbable>().Parentgrab) {
            objectInHand.GetComponentInParent<physicsObject>().setGrab(gameObject, grabbed);
        } else {
            objectInHand.GetComponent<physicsObject>().setGrab(gameObject, grabbed); //connect the grabbed object with the grabber
        }
        grabbed = true;

        // uhhh fixed joint HERE COME CHANGES TODO
        /*var joint = objectInHand.AddComponent<SpringJoint>();
        joint.breakForce = 20000;
        joint.breakTorque = 20000;
        joint.maxDistance = 5.1F;
        joint.connectedBody = gameObject.GetComponent<Rigidbody>();*/
    }

    private void ReleaseObject() {
        // only release if something is held
        if (objectInHand) {
            if (objectInHand.GetComponent<Grabbable>().Parentgrab) {
                objectInHand.GetComponentInParent<physicsObject>().release(gameObject);
            } else {
                objectInHand.GetComponent<physicsObject>().release(gameObject); //connect the grabbed object with the grabber
            }
            // Apply speed to released object TODO change bc controler =/= object
            //Future: ensure the object keeps the velocity it had just before release. Dont copy controller, don't be zero.
            //objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            //objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }
        // Remove object from hand.
        objectInHand = null;
        grabbed = false;
    }

    // Update is called once per frame
    void Update () {

        //bool grabKey = grabAction[Hand].state;
        bool grabKey = grabAction.GetStateDown(Hand);
        
        bool relKey = grabAction.GetStateUp(Hand);
        // Grab if collided
        // HairTriggerDown
        if (grabKey) {// && objectInHand == null) {
            if (collidingObject) {
                GrabObject();
                Debug.Log("Grabbed");
            }
        }

        // Release if grabbed
        //ButtonMask.Grip
        if (relKey) { 
            ReleaseObject();
        }
    }
}
