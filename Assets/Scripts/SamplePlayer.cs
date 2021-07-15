/******************************************************************************
Author: Elyas Chua-Aziz

Name of Class: DemoPlayer

Description of Class: This class will control the movement and actions of a 
                        player avatar based on user input.

Date Created: 09 / 06 / 2021
* *****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SamplePlayer : MonoBehaviour
{
    /// <summary>
    /// The distance this player will travel per second.
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotationSpeed;

    /// <summary>
    /// The camera attached to the player model.
    /// Should be dragged in from Inspector.
    /// </summary>
    public Camera playerCamera;

    private string currentState;

    private string nextState;

    //raycasting values
    [SerializeField]
    private float interactionDistance;  
    public static float DistanceFromTarget;
    public float ToTarget;

    public bool FirstQuest;
    public bool SecondQuest;
    public bool ThirdQuest;
    public bool ForthQuest;
    bool questDone=false;

    public GameObject medic;
    public GameObject energy;
    public GameObject gems;
    public float toolCount;
    public Text toolNum;

    private int Count = 0;
    // Start is called before the first frame update
    void Start()
    {
        nextState = "Idle";
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        FirstQuest = Quest.i;
        SecondQuest = Quest.t;
        ThirdQuest = Quest.y;
        ForthQuest = Quest.u;
        toolNum.text = "Tools to find " + toolCount;

        raycast();
        raycastNpc();
        if (nextState != currentState)
        {
            SwitchState();
        }

        CheckRotation();
    }

    /// <summary>
    /// Sets the current state of the player
    /// and starts the correct coroutine.
    /// </summary>
    private void SwitchState()
    {
        StopCoroutine(currentState);

        currentState = nextState;
        StartCoroutine(currentState);
    }

    private IEnumerator Idle()
    {
        while (currentState == "Idle")
        {
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") != 0) { nextState = "Moving"; }
            if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") == 0) { nextState = "Moving"; }
            if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0) { nextState = "Moving"; }
            yield return null;
        }
    }

    private IEnumerator Moving()
    {
        while (currentState == "Moving")
        {
            if (!CheckMovement())
            {
                nextState = "Idle";
            }
            yield return null;
        }
    }

    private void CheckRotation()
    {
        Vector3 playerRotation = transform.rotation.eulerAngles;
        playerRotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(playerRotation);

        Vector3 cameraRotation = playerCamera.transform.rotation.eulerAngles;
        cameraRotation.x -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        playerCamera.transform.rotation = Quaternion.Euler(cameraRotation);
    }

    /// <summary>
    /// Checks and handles movement of the player
    /// </summary>
    /// <returns>True if user input is detected and player is moved.</returns>
    private bool CheckMovement()
    {
        Vector3 newPos = transform.position;

        Vector3 xMovement = transform.right * Input.GetAxis("Horizontal");
        Vector3 zMovement = transform.forward * Input.GetAxis("Vertical");

        Vector3 movementVector = zMovement + xMovement;

        if (movementVector.sqrMagnitude > 0)
        {
            movementVector *= moveSpeed * Time.deltaTime;
            newPos += movementVector;

            transform.position = newPos;
            return false;
        }
        else
        {
            return true;
        }

    }
    void raycastNpc()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            ToTarget = Hit.distance;
            DistanceFromTarget = ToTarget;
        }
            
    }
    void raycast()
    {
        Debug.DrawLine(playerCamera.transform.position, playerCamera.transform.position + playerCamera.transform.forward * interactionDistance);
        
        int layermask = 1<< LayerMask.NameToLayer("Interactable");

        RaycastHit Hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out Hit, interactionDistance,layermask))
        {
            
            
           if (FirstQuest==true)
            {
                if (Input.GetButtonDown("Action"))
                {
                    if (Hit.transform.gameObject == medic)
                    {
                        print("quest one done");
                        Hit.transform.GetComponent<InteractableObject>().Interact();
                    }


                    questDone = true;
                }
            }
                if (SecondQuest == true)
                {
                if (Input.GetButtonDown("Action"))
                {
                    if (Hit.transform.gameObject == energy)
                    {
                        Count++;
                        print("time");
                        if (Count == 5)
                        {
                            print("quest two done");
                        }
                    }
                }
                    
                }
                if (ThirdQuest == true)
                {
                if (Input.GetButtonDown("Action"))
                {
                    if (Hit.transform.tag == "tools")
                    {
                        Hit.transform.GetComponent<InteractableObject>().Interact();
                        toolCount--;
                    }
                }
                }

                if (ForthQuest== true)
                {
                if (Hit.transform.gameObject == gems)
                    {
                    if (Input.GetButtonDown("Action"))
                    {
                        //corutine to make the the raycast hit obj
                        print("hihi");
                        StartCoroutine(suckTime());
                        
                    }
                

                    
                    
                }
                

            }
            
            
                
        }
            
    }
    IEnumerator suckTime()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSeconds(3);
        Debug.Log("ended Coroutine at timestamp : " + Time.time);
    }
}
    
