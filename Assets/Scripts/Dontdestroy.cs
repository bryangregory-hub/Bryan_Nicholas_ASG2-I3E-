using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dontdestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {//create a object that does not destroys on load
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
