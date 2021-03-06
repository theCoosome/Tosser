﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPart : MonoBehaviour {

    public GameObject myParent;

    public GameObject hitobject; //the last object to hit this part

    public static float Health;

    //When an object breaks, deal with joints.


    // Use this for initialization
    void Start () {
        Health = myParent.GetComponent<Entity>().HP;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		//for each joint, check relative velocity.
	}

    void OnTriggerEnter(Collider collider) {
        hitobject = collider.gameObject; //the object that hit this part
        Vector3 v2 = myParent.GetComponent<Rigidbody>().velocity; // my velocity
        Vector3 v1 = collider.attachedRigidbody.velocity;
        var relativeVelocity = new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z); // Worldspace relative velocity. may need to swap
        if (hitobject.GetComponent<WeaponPart>()) {
            dealSlice(hitobject.GetComponent<WeaponPart>(), relativeVelocity);
            Debug.Log("we hit a weapon");

        } else {
            Debug.Log("we hit a non-weapon: "+hitobject.name);
            if(hitobject.name == "Plane")
            {
                Rigidbody obj = myParent.GetComponent<Rigidbody>();
            }
            dealBludgeon(collider, relativeVelocity);
        }

    }

    private float dealBludgeon(Collider collider, Vector3 relativeVelocity) {
        var takendmg = relativeVelocity.magnitude * collider.attachedRigidbody.mass; //WRONG what about torque
        // Torque, if not included, is * distance between impact point and COM


        //Deal bludgeon damage with mass
        Debug.Log("we hit "+hitobject.name+", doing bludgeon damage: "+takendmg+" coming from "+relativeVelocity);
        myParent.GetComponent<Entity>().HP -= takendmg;
        return takendmg;
    }

    private void dealSlice(WeaponPart hitFrom, Vector3 relativeVelocity) {
        var impact = hitobject.transform.InverseTransformVector(relativeVelocity); //go to local space of weapon
        //transform the effective multiplier vectors into global space
        var Poseffect = hitobject.transform.TransformVector(hitFrom.effectiveVectorPos) / hitobject.GetComponent<Transform>().lossyScale.x;
        var Negeffect = hitobject.transform.TransformVector(hitFrom.effectiveVectorNeg) / hitobject.GetComponent<Transform>().lossyScale.x;

        //Debug.Log(impact+":"+impact.magnitude);
        //Debug.Log(Poseffect);

        var modCollide = new Vector3();
        //Apply the relevant multiplier to each component
        modCollide.x = (impact.x < 0) ? impact.x * Negeffect.x : impact.x * Poseffect.x;
        modCollide.y = (impact.y < 0) ? impact.y * Negeffect.y : impact.y * Poseffect.y;
        modCollide.z = (impact.z < 0) ? impact.z * Negeffect.z : impact.z * Poseffect.z;

        Debug.Log(relativeVelocity + "to" + impact + " vel, for "+ modCollide +":"+ modCollide.magnitude);

        modCollide = hitobject.transform.TransformVector(modCollide); //return to global space

        var takendmg = modCollide.magnitude * hitFrom.damage;

        Debug.Log("we hit "+hitobject.name+", doing slice damage: "+takendmg+" instead of "+modCollide);

        myParent.GetComponent<Entity>().HP -= takendmg;
        Health = myParent.GetComponent<Entity>().HP;

        ScoreBoard.Score += (int)(takendmg * 10.0);


        modCollide.x = (impact.x < 0) ? hitFrom.effectiveVectorNeg.x : hitFrom.effectiveVectorPos.x;
        modCollide.y = (impact.y < 0) ? hitFrom.effectiveVectorNeg.y : hitFrom.effectiveVectorPos.y;
        modCollide.z = (impact.z < 0) ? hitFrom.effectiveVectorNeg.z : hitFrom.effectiveVectorPos.z;
        //modCollide = hitobject.transform.TransformVector(modCollide); //return to global space
        Debug.Log("Passing " + modCollide);

        var newcomp = myParent.AddComponent<stickTracker>();
        newcomp.setup(hitFrom, modCollide);
    }

}

//idk lol