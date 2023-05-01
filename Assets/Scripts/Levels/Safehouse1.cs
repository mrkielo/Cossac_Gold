using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safehouse1 : MonoBehaviour
{
    [SerializeField] DialogueTrriger lastDialogue;
    Doors door;
    [SerializeField] GameManager gm;

    private void Start() {
        door.Close();
    }
    // Start is called before the first frame update
    void Update() {
        if(lastDialogue.done){
                door.Open();
             }
        }


}

   

