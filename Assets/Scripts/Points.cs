using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public class Points : MonoBehaviour
{
    public static int hitby = 0;

    public static DateTime time = DateTime.MinValue;
    public static DateTime t2 = DateTime.MaxValue;


    public UnityEngine.Object Axe;
    public UnityEngine.Object Pencil;
    public UnityEngine.Object Pin;
    public UnityEngine.Object target;

    public static Rigidbody Targetrb;
    public static Vector3 speed = new Vector3(-10, 8, 0);
    // Start is called before the first frame update
    void Start()
    {
        Targetrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //PrefabUtility.InstantiatePrefab(s);
        time = DateTime.Now;
        if (time >= t2 || gameObject.transform.position.x < -15.0)
        {
            //Destroy(col.gameObject);
            if (hitby == 1)
            {
                Destroy(GameObject.Find("Axe"));
                PrefabUtility.InstantiatePrefab(Axe);
            }
            if (hitby == 2)
            {
                Destroy(GameObject.Find("Pencil"));
                PrefabUtility.InstantiatePrefab(Pencil);
            }
            if (hitby == 3)
            {
                Destroy(GameObject.Find("Pin"));
                PrefabUtility.InstantiatePrefab(Pin);
            }
            if (hitby == 4)
            {
                Destroy(GameObject.Find("target"));
            }

            //Instantiate(gameObject, new Vector3(1.0F, 1.0F, 1.0F), Quaternion.identity);
            Destroy(gameObject);
            t2 = DateTime.MaxValue;
            hitby = 0;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.transform.parent.gameObject.name);
        if (col.transform.parent.gameObject.name == "Axe")
        {
            time = DateTime.Now;
            t2 = time.AddSeconds(1.5);
            hitby = 1;
        }
        if (col.transform.parent.gameObject.name == "Pencil")
        {
            time = DateTime.Now;
            t2 = time.AddSeconds(1.5);
            hitby = 2;
        }
        if (col.transform.parent.gameObject.name == "Pin")
        {
            time = DateTime.Now;
            t2 = time.AddSeconds(1.5);
            hitby = 3;
        }
    }
}

