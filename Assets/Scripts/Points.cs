using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public GameObject myParent;

    public GameObject hitobject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collider col)
    {
        if(col.gameObject.name == "Axe")
        {
            hitobject = col.gameObject; //the object that hit this part
            Vector3 v1 = myParent.GetComponent<Rigidbody>().velocity; // my velocity
            Vector3 v2 = col.attachedRigidbody.velocity;
            var relativeVelocity = new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);

            ScoreBoard.Score += (int)(col.attachedRigidbody.mass * relativeVelocity.magnitude);

            Destroy(col.gameObject);
        }
    }
}
