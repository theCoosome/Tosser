using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public class CreateTarget : MonoBehaviour
{ 
    public UnityEngine.Object target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.Find("target"))
        {
            PrefabUtility.InstantiatePrefab(target);
        }
    }
   
}
