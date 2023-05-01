using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour
{
   [SerializeField] Sprite doorsOpened;
   [SerializeField] Sprite doorsClosed;
   [SerializeField] LayerMask playerLayer;
   SpriteRenderer spriteSlot;
   public bool opened;
   [SerializeField] bool nextLevelonOpen;

   void Start() {
       spriteSlot =  GetComponent<SpriteRenderer>();
       if(opened) Open();
       else Close();
   }

   public void Open() {
        spriteSlot.enabled = true;
        opened = true;
        spriteSlot.sprite = doorsOpened;
   }

   public void Close() {
        opened = false;
        if(doorsClosed == null) spriteSlot.enabled = false;
        else spriteSlot.sprite = doorsClosed;
   }

   void Update() {
        if(opened && nextLevelonOpen && DetectPlayer()) {
            NextLevel();
        }
   }

   bool DetectPlayer() {
        return Physics2D.OverlapCircle(transform.position,0.1f,playerLayer);
   }

   void NextLevel() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        GameManager.instance.NextLevel();
   }

}
