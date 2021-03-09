using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{

    private bool press = false;

    private DateTime time1 = DateTime.MinValue;
    private DateTime time2 = DateTime.MaxValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time1 = DateTime.Now;
        if (press && time1 > time2)
        {
            Points.Targetrb.velocity = Points.speed;
            press = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col. gameObject.name != "table" && col.gameObject.name != "Plane")
        {
            //Points.Targetrb.velocity = Points.speed;
            press = true;
            time1 = DateTime.Now;
            time2 = time1.AddSeconds(1.5);
        }
    }
}
