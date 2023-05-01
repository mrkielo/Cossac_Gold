using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTrriger : MonoBehaviour
{
    DialogueTrriger trriger;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float radius;
    [SerializeField] Dialogue d;

    private void Start() {
        
        trriger = GetComponent<DialogueTrriger>();
    }

     void Update() {
        if(Physics2D.OverlapCircle(transform.position,radius,playerLayer)) {
            trriger.StartDialogue(d);
            Destroy(this);
        }
    }
}
