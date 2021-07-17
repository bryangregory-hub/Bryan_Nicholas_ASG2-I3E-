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
    
    public static int questDone = 0;

    public GameObject medic;
    public GameObject energy;
    public GameObject gems;
    public float toolCount;
    public Text toolNum;

    private int Count = 0;
    private IEnumerator suckTime;

    public GameObject NPC_1;
    public GameObject NPC_2;
    public GameObject NPC_3;
    public GameObject NPC_4;


    public GameObject questDone1;
    public GameObject questDone2;
    public GameObject questDone3;
    public GameObject questDone4;

    public Animator pickaxe;
    public GameObject pixace;
    public GameObject exrtractor;
    public Animator QuestD;
    public Animator GamWin;
    public Slider Qn2S;
    public GameObject Qns2;

    public static bool Q1;
    public static bool Q2;
    public static bool Q3;
    public static bool Q4;
    // Start is called before the first frame update
    void Start()
    {
        questDone = 0;
        nextState = "Idle";
        Cursor.lockState = CursorLockMode.Locked;
        //identifies if the which quest is avalible complete
        Q1 = false;
        Q2 = false;
        Q3 = false;
        Q4 = false;
    }

    // Update is called once per frame
    void Update()
    {

        Qn2S.value = Count;
        
        suckTime = Sucking();
        //refering back to Quest scripts
        FirstQuest = Quest.i;
        SecondQuest = Quest.t;
        ThirdQuest = Quest.y;
        ForthQuest = Quest.u;
        toolNum.text = "Tools to find " + toolCount;
        //if all 4 quest is claim ship is ready to board
        if (Input.GetButton("Win")|| questDone==4)
        {
            print("all quest completed");
            GamWin.SetBool("Win", true);
        }
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
        // this raycast identifist the distance from the player and an object
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

        int layermask = 1 << LayerMask.NameToLayer("Interactable");

        RaycastHit Hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out Hit, interactionDistance, layermask))
        {


            //when player accepts the quest, press e to interact with item
            if (FirstQuest == true)
            {
                if (Input.GetButtonDown("Action") && Q1 != true)
                {
                    if (Hit.transform.gameObject == medic)
                    {
                        //print("quest one done");
                        //play animation
                        QuestD.SetBool("QD", true);
                        Hit.transform.GetComponent<InteractableObject>().Interact();
                        //disables the interation with NPC when quest is done by switching quest.
                        NPC_1.gameObject.tag = "Untagged";
                        questDone1.gameObject.SetActive(false);
                        Q1 = true;
                        questDone++;
                        
                        StartCoroutine(qDone());

                    }
                }
            }
            if (SecondQuest == true)
            {
                if (Input.GetButtonDown("Action") && Q2 != true)
                {
                    if (Hit.transform.gameObject == energy)
                    {
                        Qns2.gameObject.SetActive(true);
                        Count++;
                        exrtractor.SetActive(true);

                       
                        if (Count == 5)
                        {
                            QuestD.SetBool("QD", true);
                            exrtractor.SetActive(false);
                            //print("quest two done");
                            NPC_2.gameObject.tag = "Untagged";
                            questDone2.gameObject.SetActive(false);
                            Q2 = true;
                            StartCoroutine(qDone());
                            questDone++;
                            Qns2.gameObject.SetActive(false);
                        }
                        
                            
                        
                    }
                    //exrtractor.SetActive(false);
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
                        if (toolCount == 0)
                        {
                            QuestD.SetBool("QD", true);
                            NPC_3.gameObject.tag = "Untagged";
                            questDone3.gameObject.SetActive(false);
                            Q3 = true;
                            //print("quest three done");
                            StartCoroutine(qDone());
                            questDone++;
                        }
                    }
                }
            }

            if (ForthQuest == true)
            {
                if (Hit.transform.gameObject == gems)
                {
                    //print("looking at gems");
                    if (Input.GetButtonDown("Action") && Q4 != true)
                    {

                        pixace.SetActive(true);
                        pickaxe.SetBool("Mine", true);
                        NPC_4.gameObject.tag = "Untagged";

                        //corutine to make the the raycast hit obj
                        StartCoroutine(Sucking());

                    }
                    if (Q4 == true)
                    {
                        Hit.transform.GetComponent<InteractableObject>().Interact();
                    }
                }
                

            }
        }
    }
    //this coroutine help give a pause so that the animation can fully play out 
    IEnumerator qDone()
    {
        yield return new WaitForSeconds(0.5f    );
        //print("waited");
        QuestD.SetBool("QD", false);
    }
    //this is used for the 2 quest for user to interact with stone
    IEnumerator Sucking()
    {
        yield return new WaitForSeconds(3);
        //print("quest four done");
        pickaxe.SetBool("Mine", false);
        Q4 = true;
        QuestD.SetBool("QD", true);
        
        questDone++;
        questDone4.gameObject.SetActive(false);
        pixace.SetActive(false);
    }
}