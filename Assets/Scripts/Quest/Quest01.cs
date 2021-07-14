using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest01 : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject QuestText;
    public GameObject QuestDetail;
    public static bool i = false;
    

    void Update()
    {
        TheDistance = SamplePlayer.DistanceFromTarget;
        
        Quest();
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
                QuestText.SetActive(true);
                QuestDetail.SetActive(true);
                i = true;
                print("got it");
                
            }
                
        }
    }
     void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        QuestDetail.SetActive(false);
    }
    public void Quest()
    {
        if (i == true)
        {
            
        }
    }

}
