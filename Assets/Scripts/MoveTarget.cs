using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public static bool hard = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hard == true && GameObject.Find("target").GetComponent<Rigidbody>().velocity == new Vector3 (0, 0, 0))
        {
            GameObject.Find("target").transform.position = new Vector3(15.0F, 1.0F, 45.0F);
        }
        else if (hard == false && GameObject.Find("target").GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0))
        {
            GameObject.Find("target").transform.position = new Vector3(15.0F, 1.0F, 8.5F);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name != "Plane")
        {
            Debug.Log("Made it");
            if (hard == false)
            {
                hard = true;
            }
            else
            {
                hard = false;
            }
        }
    }
}
