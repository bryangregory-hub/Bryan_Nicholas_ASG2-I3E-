using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_template : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject QuestText;

    


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
        else
        {
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                QuestText.SetActive(true);
                
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
