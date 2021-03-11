using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CreateTarget : MonoBehaviour
{ 
    public UnityEngine.Object target;
    public UnityEngine.Object tarA;
    public UnityEngine.Object tarB;

    public GameObject health;

    private DateTime time1 = DateTime.MinValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("target") && time1 < DateTime.Now)
        {
            if (time1 != DateTime.MinValue)
            {
                Destroy(GameObject.Find("targetBa"));
                Destroy(GameObject.Find("targetBb"));
                time1 = DateTime.MinValue;
            }
            //PrefabUtility.InstantiatePrefab(target);
            Quaternion quat = new Quaternion(0, 0, 0, 0);
            quat.eulerAngles = new Vector3(0, 0, 0);
            Instantiate(target, new Vector3(15F, 1F, 8.5F), quat).name = "target";
        }
        else if (HitPart.Health < 0.0)
        {
            Vector3 pos = GameObject.Find("target").transform.position;
            Quaternion rot = GameObject.Find("target").transform.rotation;
            Vector3 vel = GameObject.Find("target").GetComponent<Rigidbody>().velocity;
            Destroy(GameObject.Find("target"));
            //PrefabUtility.InstantiatePrefab(tarA);
            Instantiate(target, pos, rot).name = "targetBa";
            GameObject.Find("targetBa").GetComponent<Rigidbody>().velocity = vel;
            //PrefabUtility.InstantiatePrefab(tarB);
            Instantiate(target, pos, rot).name = "targetBb";
            GameObject.Find("targetBb").GetComponent<Rigidbody>().velocity = vel;
            time1 = DateTime.Now.AddSeconds(1.5);
        }
    }
   
}
