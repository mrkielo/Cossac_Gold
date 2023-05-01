using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float currentDir;
    EnemyMovement m;
    [SerializeField] float stopTime;
    [SerializeField] GameObject ImpactPrefab;

    [Header("Ranges")]
    [SerializeField] float turnRayRange;
    [SerializeField] float caughtRange;
    Animator animator;

    bool closeRay = false;

    Player player;
    bool stopped = false;
    bool shooted = false;
    int i=0;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        m = GetComponent<EnemyMovement>();
        m.Walk(currentDir);
    }


    void Update()
    {
        RaycastTurns();
        StartCoroutine(RaycastStops());
        StartCoroutine(RaycastPlayer());
            

    }

    void RaycastTurns() {
        bool turnRay = Physics2D.Raycast(transform.position,Vector2.right,turnRayRange * currentDir,LayerMask.GetMask("EnemyTurn","Ground"));
        Debug.DrawRay(transform.position,Vector3.right * turnRayRange * currentDir,Color.blue);
        if(turnRay) {
            currentDir = -currentDir;
             m.Walk(currentDir);
        }
    }

    IEnumerator RaycastStops() {
        bool stopRay = Physics2D.Raycast(transform.position, Vector2.right,0.1f * currentDir,LayerMask.GetMask("EnemyStop"));

        if(stopRay && stopped==false) {
            stopped = true;
            m.Stop();
            yield return new WaitForSeconds(stopTime);
            m.Walk(currentDir);
        }
        else {
            stopped = false;
        }
    }

    IEnumerator RaycastPlayer() {
        RaycastHit2D playerRay = Physics2D.Raycast(transform.position, Vector2.right, caughtRange * currentDir, LayerMask.GetMask("Player"));
        bool wallRay = Physics2D.Raycast(transform.position,player.transform.position - transform.position, Vector2.Distance(player.transform.position,transform.position),player.GetComponent<PlayerMovement>().groundLayers);

        closeRay = Physics2D.OverlapCircle(transform.position,1f,LayerMask.GetMask("Player"));
        

        Debug.DrawRay(transform.position,Vector3.right * caughtRange * currentDir,Color.red);
        Debug.DrawRay(transform.position,player.transform.position,Color.white);

        if((playerRay || closeRay) && !wallRay && !GameManager.instance.playerDied && !player.isHiding) {
            if(player.transform.position.x<transform.position.x) currentDir = -1;
            else if(player.transform.position.x>=transform.position.x) currentDir = 1;
            yield return  new WaitForFixedUpdate();
            m.Walk(currentDir);
            yield return  new WaitForFixedUpdate();
            m.Stop();
            yield return new WaitForFixedUpdate();
            StartCoroutine(Shoot(playerRay));
            GameManager.instance.playerDied = true;
        }
        yield return new WaitForEndOfFrame();
    }

    IEnumerator Shoot(RaycastHit2D playerRay) {
        player.dead = true;
        player.GetComponent<PlayerMovement>().canMove = false;
        player.GetComponent<PlayerMovement>().canJump = false;
        animator.SetTrigger("shoot");
        yield return new WaitForSeconds(0.2f);
        GameObject impact = Instantiate(ImpactPrefab,new Vector2(playerRay.point.x - currentDir/2, playerRay.point.y),transform.rotation);
        if(closeRay) {
            impact.GetComponent<SpriteRenderer>().enabled = false;
        }
        impact.transform.localScale = transform.localScale;
        yield return new WaitForSeconds(0.5f);
        player.Die();
    }

}