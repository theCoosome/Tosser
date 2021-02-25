using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPart : MonoBehaviour {

    public GameObject myParent;

    public GameObject hitobject; //the last object to hit this part


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision) {
        hitobject = collision.collider.gameObject; //the object that hit this part
        if (hitobject.GetComponent<WeaponPart>()) {
            if (hitobject.GetComponent<WeaponPart>().slice) dealSlice(hitobject.GetComponent<WeaponPart>(), collision);

        } else {
            Debug.Log("we hit a non-weapon: "+hitobject.name);
            dealBludgeon(collision);
        }
    }

    private float dealBludgeon(Collision collision) {
        var takendmg = collision.relativeVelocity.magnitude * collision.gameObject.GetComponentInParent<Rigidbody>().mass; //WRONG what about torque


        //Deal bludgeon damage with mass
        Debug.Log("we hit "+hitobject.name+", doing bludgeon damage: "+takendmg+" coming from "+collision.relativeVelocity);
        myParent.GetComponent<Entity>().HP -= takendmg;
        return takendmg;
    }

    private void dealSlice(WeaponPart hitFrom, Collision collision) {
        
        var initialImpact = dealBludgeon(collision); //Get bludgeon
        var impact = hitobject.transform.InverseTransformVector(collision.relativeVelocity); //go to local space of weapon
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

        Debug.Log(modCollide +":"+ modCollide.magnitude);

        modCollide = hitobject.transform.TransformVector(modCollide); //return to global space

        var takendmg = modCollide.magnitude * hitFrom.damage;

        Debug.Log("we hit "+hitobject.name+", doing slice damage: "+takendmg+" instead of "+modCollide);

        myParent.GetComponent<Entity>().HP -= takendmg;
    }

}

//idk lol