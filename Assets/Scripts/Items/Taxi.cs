using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Taxi : MonoBehaviour
{
   
   [SerializeField] float speed;
   [SerializeField] Transform end;
    void Update()
    {
       GetComponent<Rigidbody2D>().velocity = Vector2.right * speed; 

       if(transform.position.x > end.position.x) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       }
    }
}
