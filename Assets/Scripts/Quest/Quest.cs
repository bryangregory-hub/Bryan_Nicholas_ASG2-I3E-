using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject QuestText;
    public GameObject QuestDetail;
    
    public static bool i = false;
    public static bool t = false;
    public static bool y = false;


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
        if (TheDistance>=3)
        {
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            QuestDetail.SetActive(false);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
                
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                QuestText.SetActive(true);
                QuestDetail.SetActive(true);
                if (gameObject.tag=="NPC 1")
                {
                    i = true;
                    Debug.Log(name + " has been interacted with.");
                }
                if (gameObject.tag == "NPC 2")
                {
                    t = true;
                    Debug.Log(name + " has been interacted with.");
                }

                if (gameObject.tag == "NPC 3")
                {
                    y = true;
                    Debug.Log(name + " has been interacted with.");
                }


            }
                
        }
    }
     void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        QuestDetail.SetActive(false);
    }
    

}
