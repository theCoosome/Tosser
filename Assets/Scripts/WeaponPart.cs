using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPart : MonoBehaviour {

    //Used to tell other components that it is a damage dealer and stores that information

    public int damage;

    public Vector3 effectiveVectorPos;
    public Vector3 effectiveVectorNeg;

    public GameObject parent;
    //public Component[] Colliders;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
