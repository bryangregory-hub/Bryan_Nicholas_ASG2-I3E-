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
        
<<<<<<< HEAD
        
=======
        Quest();
>>>>>>> 1092396fcf02ef0d365d3dfd179c3bcf1d401ade
    }
     void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
<<<<<<< HEAD
        if (TheDistance>=3)
        {
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            QuestDetail.SetActive(false);
        }
=======
        
>>>>>>> 1092396fcf02ef0d365d3dfd179c3bcf1d401ade
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
    

}
