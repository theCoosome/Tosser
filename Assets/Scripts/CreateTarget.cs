using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CreateTarget : MonoBehaviour
{ 
    private GameObject Axe;
    private GameObject Pencil;
    private GameObject Pin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Points.time = DateTime.Now;
        if (Points.time >= Points.t2)
        {
            //Destroy(col.gameObject);
            if (Points.hitby == 1)
            {
                Axe = GameObject.Find("Axe");
                Destroy(Axe);
                Instantiate(Axe, new Vector3(physicsObject.AxePosx, physicsObject.AxePosy, physicsObject.AxePosz), Quaternion.identity);
            }
            if (Points.hitby == 2)
            {
                Pencil = GameObject.Find("Pencil");
                Destroy(Pencil);
                Instantiate(Pencil, new Vector3(physicsObject.PencilPosx, physicsObject.PencilPosy, physicsObject.PencilPosz), Quaternion.identity);
            }
            if (Points.hitby == 3)
            {
                Pin = GameObject.Find("Pin");
                Destroy(Pin);
                Instantiate(Pin, new Vector3(physicsObject.PinPosx, physicsObject.PinPosy, physicsObject.PinPosz), Quaternion.identity);
            }
            Destroy(GameObject.Find("target"));
            Points.t2 = DateTime.MaxValue;
            Instantiate(GameObject.Find("target"), new Vector3(1.0F, 1.0F, 1.0F), Quaternion.identity);
            Points.hitby = 0;
            //this.transform.position = startPos;
        }
    }
}
