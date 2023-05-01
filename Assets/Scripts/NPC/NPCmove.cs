using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmove : MonoBehaviour
{
    [SerializeField] float speedAndDir;
    [SerializeField] Transform stopX;
    [SerializeField] bool destroyAfterStop;
    public bool stopped = false;
    Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

     void Update() {
        if(GetComponentInChildren<DialogueTrriger>().done){
            rb.velocity = Vector2.right * speedAndDir;
            //if(speedAndDir>0) transform.localScale = new Vector2(1,1);
            //if(speedAndDir<0) transform.localScale = new Vector2(-1,1);

        
        }
        if(speedAndDir>0 && transform.position.x >= stopX.position.x) {
            Stop();
        }
        if(speedAndDir<0 && transform.position.x <= stopX.position.x) {
            Stop();
        }

    }
    void Stop() {
        stopped = true;
        rb.velocity = Vector2.zero;
        if(destroyAfterStop) Destroy(gameObject);
    }
}
