using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Points : MonoBehaviour
{
    public GameObject myParent;

    public GameObject Axe;
    public GameObject Pencil;
    public GameObject Pin;

    public static int hitby = 0;

    public static DateTime time = DateTime.MinValue;
    public static DateTime t2 = DateTime.MaxValue;
    private float startPosx;
    private float startPosy;
    private float startPosz;

    // Start is called before the first frame update
    void Start()
    {
        startPosx = transform.position.x;
        startPosy = transform.position.y;
        startPosz = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.StartsWith("Axe"))
        {
            time = DateTime.Now;
            t2 = time.AddSeconds(5);
            hitby = 1;
        }
        if (col.gameObject.name.StartsWith("Pencil"))
        {
            time = DateTime.Now;
            t2 = time.AddSeconds(5);
            hitby = 2;
        }
        if (col.gameObject.name.StartsWith("Pin"))
        {
            time = DateTime.Now;
            t2 = time.AddSeconds(5);
            hitby = 3;
        }
      /*  if (col.gameObject.name == "Plane")
        {
            time = DateTime.Now;
            t2 = time.AddSeconds(5);
        }*/
    }
}

