using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Points : MonoBehaviour
{
    public GameObject myParent;

    public GameObject hitobject;

    public static DateTime time = DateTime.MinValue;
    public static DateTime t2 = DateTime.MaxValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time = DateTime.Now;
        if (time >= t2)
        {
            //Destroy(col.gameObject);
            Destroy(gameObject);
            t2 = DateTime.MaxValue;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Axe")
        {
            time = DateTime.Now;
            t2 = time.AddSeconds(5);
        }
    }
}

