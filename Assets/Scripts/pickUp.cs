using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    public Transform theDest;

    


    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = theDest.position;
            this.transform.parent = GameObject.Find("Destination").transform;
            
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
    void OnMouseExit()
    {
        
    }
}
