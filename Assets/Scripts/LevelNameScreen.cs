using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNameScreen : MonoBehaviour
{
    [SerializeField] float time = 1;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        StartCoroutine("Play");
    }

    IEnumerator Play() {
        bool canMoved;
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        if(player.canMove) {
            player.canMove = false;
            canMoved = true;
        } else canMoved = false;
    
        yield return new WaitForSeconds(time);
        GetComponent<Fade>().Out(time);
        yield return new WaitForSeconds(time);
        if(canMoved) player.canMove = true;
        Destroy(gameObject);


    }

    
}
