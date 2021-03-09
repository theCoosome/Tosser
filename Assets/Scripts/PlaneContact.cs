using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public class PlaneContact : MonoBehaviour
{
    private DateTime time1 = DateTime.MinValue;
    private DateTime time2 = DateTime.MaxValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Pin").transform.position.y < 0)
        {
            //Points.time = DateTime.Now;
            Points.t2 = DateTime.Now;
            Points.hitby = 3;
        }
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.transform.parent.gameObject.name == "Axe")
        {
            //Points.time = DateTime.Now;
            Points.t2 = DateTime.Now.AddSeconds(3);
            Points.hitby = 1;
        }
        if (col.transform.parent.gameObject.name == "Pencil")
        {
            //Points.time = DateTime.Now;
            Points.t2 = DateTime.Now.AddSeconds(3);
            Points.hitby = 2;
        }
        if (col.transform.parent.gameObject.name == "Pin")
        {
            //Points.time = DateTime.Now;
            Points.t2 = DateTime.Now.AddSeconds(3);
            Points.hitby = 3;
        }

    }
}
