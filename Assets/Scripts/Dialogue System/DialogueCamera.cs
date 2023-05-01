using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DialogueCamera : MonoBehaviour
{
    [SerializeField] float upMove;
    [SerializeField] Transform player;
    CinemachineVirtualCamera cm;
    bool modeG = false;
    

    void Awake() {
        cm = Camera.main.GetComponentInChildren<CinemachineVirtualCamera>();
    }
    void Start() {
        SetMode(false);
    }
     void FixedUpdate() {
        if(!modeG) transform.position = player.position;
    }


    public void SetMode(bool mode,Transform customPos = null, float smooth = 5) {
        if(mode == true) {
            modeG = true;
            cm.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = smooth;
            
            if(customPos==null)  transform.position = new Vector2(player.position.x, player.position.y + upMove);
            else {
                transform.position = customPos.position;
                cm.GetComponent<CinemachineConfiner>().enabled= false;
            }
            
        } else {
            modeG = false;
            transform.position = player.position;  
            cm.GetComponent<CinemachineConfiner>().enabled= true;
            cm.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = 1;
        }
       
    }

       
}

