using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest02 : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject QuestText;
    public GameObject QuestDetail;
    public static bool t = false;


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
        if (TheDistance >= 3)
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
                t = true;
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
