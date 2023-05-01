using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float ix;
    [SerializeField] float runSpeed;
    [SerializeField] float walkSpeed;
    float speed;

    Rigidbody2D rb;


    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(ix * speed,rb.velocity.y);
    }

    public void Walk(float dir) {
        ix = dir;
        speed = walkSpeed;
    }

    public void Run(float dir) {
        ix = dir;
        speed = runSpeed;
    }

    public void Stop() {
        ix = 0;
        
    }

}
