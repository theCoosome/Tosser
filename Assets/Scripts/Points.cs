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

    private int hitby = 0;

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
        time = DateTime.Now;
        if (time >= t2)
        {
            //Destroy(col.gameObject);
            if (hitby == 1)
            {
                Destroy(Axe);
                Instantiate(Axe, new Vector3(physicsObject.AxePosx, physicsObject.AxePosy, physicsObject.AxePosz), Quaternion.identity);
            }
            if (hitby == 2)
            {
                Destroy(Pencil);
                Instantiate(Pencil, new Vector3(physicsObject.PencilPosx, physicsObject.PencilPosy, physicsObject.PencilPosz), Quaternion.identity);
            }
            if (hitby == 3)
            {
                Destroy(Pin);
                Instantiate(Pin, new Vector3(physicsObject.PinPosx, physicsObject.PinPosy, physicsObject.PinPosz), Quaternion.identity);
            }
            Destroy(gameObject);
            t2 = DateTime.MaxValue;
            Instantiate(myParent, new Vector3(startPosx, startPosy, startPosz), Quaternion.identity);
            hitby = 0;
            //this.transform.position = startPos;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name != "Plane")
        {
            time = DateTime.Now;
            t2 = time.AddSeconds(5);
            hitby = 1;
        }
        if (col.gameObject.name == "Pencil")
        {
            time = DateTime.Now;
            t2 = time.AddSeconds(5);
            hitby = 2;
        }
        if (col.gameObject.name == "Pin")
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

