using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueTrriger : MonoBehaviour
{
    DialogueManager manager;
    public bool done;

    void Awake() {
        done = false;
        manager = FindObjectOfType<DialogueManager>();
    }
     void Start() {
        manager.gameObject.SetActive(false);
    }

    public void StartDialogue(Dialogue d) {
        manager.gameObject.SetActive(true);
        if(!manager.activeDialogue){
        manager.CoroutineDialogue(d);
        Debug.Log("Starting dialogue with " + d.name);
        manager.OnDialogueEnded += DialogueEnd;
        }
    }

    public void DialogueEnd(object sender, EventArgs e) {
        manager.gameObject.SetActive(false);
        done = true;
    }
   
}
