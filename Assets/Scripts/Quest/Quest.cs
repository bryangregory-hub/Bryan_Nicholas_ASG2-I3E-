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
<<<<<<< HEAD
    public GameObject WinF;
    public int Win;
    private bool p=false;
    public static bool i;
    public static bool t;
    public static bool y;
    public static bool u;

    void Start()
    {
        i = false;
        t = false;
        y = false;
        u = false;
    }
    void Update()
    {
        TheDistance = SamplePlayer.DistanceFromTarget;


        Win = SamplePlayer.questDone;
    }
    private void FixedUpdate()
    {
        if (p == true)
        {
            StartCoroutine(wait());
        }
        else if (p == false)
        {
            ActionText.SetActive(false);
        }

    }
    void OnMouseOver()
    {
        if (gameObject.tag=="winCap"&& Win==4)
        {
            WinF.gameObject.SetActive(true);
            ActionText.SetActive(false);
        }
=======
    
    public static bool i = false;
    public static bool t = false;
    public static bool y = false;
    public static bool u = false;

  
    void Update()
    {
        TheDistance = SamplePlayer.DistanceFromTarget;
        


    }
     void OnMouseOver()
    {
>>>>>>> da0ddee7e15939205c99fb7adc1ca7bb1d9856f9
        if (TheDistance>=3)
        {
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            QuestDetail.SetActive(false);
        }
<<<<<<< HEAD
        if (gameObject.tag!="Untagged"|| gameObject.tag=="Int NPC"|| gameObject.tag=="tools"&&Win!=4)
=======
        if (gameObject.tag!="Untagged"|| gameObject.tag=="Int NPC")
>>>>>>> da0ddee7e15939205c99fb7adc1ca7bb1d9856f9
        {
            if (TheDistance <= 3)
            {
                ActionDisplay.SetActive(true);
                ActionText.SetActive(true);
<<<<<<< HEAD

                p = true;
=======
>>>>>>> da0ddee7e15939205c99fb7adc1ca7bb1d9856f9
            }
            if (Input.GetButtonDown("Action"))
            {
                if (TheDistance <= 3)
                {

                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    QuestText.SetActive(true);
                    QuestDetail.SetActive(true);
<<<<<<< HEAD
                    
=======
>>>>>>> da0ddee7e15939205c99fb7adc1ca7bb1d9856f9
                    if (gameObject.tag == "NPC 1")
                    {
                        i = true;
                        //Debug.Log(name + " has been interacted with.");
                    }
                    if (gameObject.tag == "NPC 2")
                    {
                        t = true;
                        //Debug.Log(name + " has been interacted with.");
                    }

                    if (gameObject.tag == "NPC 3")
                    {
                        y = true;
                        //Debug.Log(name + " has been interacted with.");
                    }
                    if (gameObject.tag == "NPC 4")
                    {
                        u = true;
                        //Debug.Log(name + " has been interacted with.");
                    }
                }
            }
        }
        
    }
<<<<<<< HEAD
     IEnumerator wait()
    {
        p = false;
        yield return new WaitForSeconds(1f);
        
        ActionText.SetActive(false);
        

    }
=======
>>>>>>> da0ddee7e15939205c99fb7adc1ca7bb1d9856f9
     void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        QuestDetail.SetActive(false);
    }
    

}
