using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fortress_entrance : MonoBehaviour
{
    [SerializeField] GameObject guard;
    
    void Start() {


    }

    // Update is called once per frame
    void Update()
    {
        if(guard.GetComponent<NPCmove>().stopped) {
        
        }
    }
}
