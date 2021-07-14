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
<<<<<<< HEAD
    public GameObject QuestDetail;
=======
    
>>>>>>> e1ab0d216a7f47acce7de05f5a4f0fb68fbc7009
    public static bool i = false;
    

    void Update()
    {
        TheDistance = SamplePlayer.DistanceFromTarget;
<<<<<<< HEAD
        
=======
>>>>>>> e1ab0d216a7f47acce7de05f5a4f0fb68fbc7009
        Quest();
    }
     void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
<<<<<<< HEAD
        
=======
        else
        {
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
        }
>>>>>>> e1ab0d216a7f47acce7de05f5a4f0fb68fbc7009
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
<<<<<<< HEAD
                
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                QuestText.SetActive(true);
                QuestDetail.SetActive(true);
                i = true;
                print("got it");
                
            }
                
=======
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                QuestText.SetActive(true);
                i = true;
                print("got it");
            }
>>>>>>> e1ab0d216a7f47acce7de05f5a4f0fb68fbc7009
        }
    }
     void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
<<<<<<< HEAD
        QuestDetail.SetActive(false);
=======
>>>>>>> e1ab0d216a7f47acce7de05f5a4f0fb68fbc7009
    }
    public void Quest()
    {
        if (i == true)
        {
            
        }
    }

}
