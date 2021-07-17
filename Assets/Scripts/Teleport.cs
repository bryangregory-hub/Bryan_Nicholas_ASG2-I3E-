using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;
    int win;
    void OnTriggerEnter(Collider other)
    {//teleports player back to the main room
        if (gameObject.tag=="Untagged")
        {
            thePlayer.transform.position = teleportTarget.transform.position;
        }
        //check is won 
        if (win == 4&&gameObject.tag=="winCap")
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
    void Update()
    {
        win = SamplePlayer.questDone;

    }

}
