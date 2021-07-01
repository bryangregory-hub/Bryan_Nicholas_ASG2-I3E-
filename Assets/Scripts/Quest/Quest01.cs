using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest01 : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    

    void Update()
    {
        TheDistance = SamplePlayer.DistanceFromTarget;
    }
     void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                print("got it");
            }
        }
    }
     void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

}
