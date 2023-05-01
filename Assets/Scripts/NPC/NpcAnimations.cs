using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAnimations : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

     void Update() {
        if(rb.velocity.x>0) {
            animator.SetFloat("mx",1);
            if(transform.localScale.x>0) Flip();
        }

        if(rb.velocity.x<0) {
            animator.SetFloat("mx",1);
            if(transform.localScale.x<0) Flip();
        }

        if(rb.velocity.x==0) {
            animator.SetFloat("mx",0);
        }
    }

    void Flip() {
        transform.localScale = new Vector2(-transform.localScale.x,transform.localScale.y);
    }

}
