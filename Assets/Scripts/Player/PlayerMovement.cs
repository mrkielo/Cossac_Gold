using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [HideInInspector] public float mx;
    [HideInInspector] public float my;
    float ix;

    [SerializeField] public float runSpeed;
    [SerializeField] public float walkSpeed;
    public float speed;
    [SerializeField] float jumpForce;

    [SerializeField] Transform foot;
    [SerializeField] public LayerMask groundLayers;
    [SerializeField] float coyoteTime;
    float coyoteTimeCounter;

    public bool canJumpstate;
    [HideInInspector] public bool canJump;
    public bool canMove;
    public bool isWalking;

    Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        canJump = canJumpstate;

    }

    void Update() {
        
        if(canMove) ix = Input.GetAxis("Horizontal");
        else ix=0;
        if(Input.GetButtonDown("Fire1") && coyoteTimeCounter>0 && canJump) {
            rb.velocity = new Vector2(rb.velocity.x,0);
            Jump();
        }

        

        my = rb.velocity.y;
        mx = rb.velocity.x;

        if(GetComponent<Player>().isPulling) {
            if(isWalking) speed = walkSpeed/2;
            else speed = runSpeed/2;
        }else {
            if(isWalking) speed = walkSpeed;
            else speed = runSpeed;
        }

        

        if(isGrounded() && coyoteTimeCounter>-1) {
            coyoteTimeCounter = coyoteTime;
        } else {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(!isGrounded() && coyoteTimeCounter<=-1) {
            coyoteTimeCounter=0;
        }

        if(Input.GetButtonUp("Fire1")) {
            coyoteTimeCounter = 0;
        }


        if(mx>0 && transform.localScale.x > 0) {
            Flip();
        }
        if(mx<0 && transform.localScale.x <0) {
            Flip();
        }



    }

    void FixedUpdate() {
        rb.velocity = new Vector2(ix * speed,rb.velocity.y);
        
    }

    void Jump() {
        rb.AddForce(new Vector2(0,jumpForce));
        coyoteTimeCounter = -1;
    }

    public bool isGrounded() {
        return Physics2D.OverlapCircle(foot.position,0.1f,groundLayers);
    }

    void Flip() {
        if(GetComponent<Player>().isPulling == false)
        transform.localScale = new Vector2(-transform.localScale.x,transform.localScale.y);
    }


}
