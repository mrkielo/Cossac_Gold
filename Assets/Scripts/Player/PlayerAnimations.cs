using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    
    PlayerMovement movement;
    Animator animator;

    void Start() {
       movement = GetComponent<PlayerMovement>();
       animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("mx",Mathf.Abs(movement.mx));
        animator.SetFloat("my",movement.my);
    }
}
