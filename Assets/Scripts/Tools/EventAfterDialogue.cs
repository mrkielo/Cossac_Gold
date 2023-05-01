using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventAfterDialogue : MonoBehaviour
{
    [SerializeField] UnityEvent afterDialogueEnd;
    [SerializeField] DialogueTrriger dialogue;

     void Update() {
        if(dialogue.done) {
            afterDialogueEnd.Invoke();
        }
    }
   


}
