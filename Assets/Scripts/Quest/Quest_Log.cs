using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Log : MonoBehaviour
{
    public  bool LogQ1;
    public bool LogQ2;
    public bool LogQ3;
    public bool LogQ4;
    public bool QuestD1;
    public bool QuestD2;
    public bool QuestD3;
    public bool QuestD4;

    public GameObject Mission_Log;

    
    public Text Qdetail1;
    public Text Qdetail2;
    public Text Qdetail3;
    public Text Qdetail4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {//tab will toggle the menu open
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Mission_Log.gameObject.SetActive(true);
            QuestClaim();
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Mission_Log.gameObject.SetActive(false);
        }
    }
    //this is to show if the quest is avalible where to find it and/or if its completed 
    public void QuestClaim()
    {
        LogQ1 = Quest.i;
        LogQ2 = Quest.t;
        LogQ3 = Quest.y;
        LogQ4 = Quest.u;

        QuestD1 = SamplePlayer.Q1;
        QuestD2 = SamplePlayer.Q2;
        QuestD3 = SamplePlayer.Q3;
        QuestD4 = SamplePlayer.Q4;
        if (LogQ1 == true)
        {
            Qdetail1.text= "Hint(Building) Medic kit";
            if (QuestD1==true)
            {
                Qdetail1.text = "Medic kit "+"[Complete]";
            }
        }
        if (LogQ2 == true)
        {
            Qdetail2.text = "Hint(cave) Mine energy";
            if (QuestD2 == true)
            {
                Qdetail2.text = "Mine energy " + "[Complete]";
            }
        }
        if (LogQ3 == true)
        {
            Qdetail3.text = "Hint(building) Find tools";
            if (QuestD3 == true)
            {
                Qdetail3.text = "Find tools " + "[Complete]";
            }
        }
        if (LogQ4 == true)
        {
            Qdetail4.text = "Hint(cave) Get meterials";
            if (QuestD4 == true)
            {
                Qdetail4.text = "Get meterials " + "[Complete]";
            }
        }
    }
}