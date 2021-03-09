using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{

    private bool press = false;

    private DateTime time1 = DateTime.MinValue;
    private DateTime time2 = DateTime.MaxValue;

    public Vector3 speed;

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
            if (MoveTarget.hard == false)
            {
                Points.Targetrb.velocity = speed;
            }
            else
            {
                Points.Targetrb.velocity = new Vector3 (speed.x, speed.y, -40);
            }
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
            time2 = time1.AddSeconds(1);
        }
    }
}
