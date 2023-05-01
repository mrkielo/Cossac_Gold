using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public event EventHandler OnDialogueEnded;


    CanvasGroup canvasGroup;
    PlayerMovement player;
    DialogueCamera camera;
    [SerializeField] Image avatar;
    [SerializeField] Sprite artemAvatar;
    bool space;
    [SerializeField] Text name;
    [SerializeField] Text text;
    [SerializeField] GameObject spaceText;
    [SerializeField] float letterDelay = 0.05f;
    public bool activeDialogue;
    Dialogue dialogue;



    bool showMenu;
    
    void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
        camera = FindObjectOfType<DialogueCamera>();
        activeDialogue = false;
        canvasGroup = GetComponent<CanvasGroup>();
        HideMenu();

    }

    public void CoroutineDialogue(Dialogue d) {
        dialogue = d;
        StartCoroutine("StartDialogue");
    }

    IEnumerator StartDialogue() {
        spaceText.SetActive(false);
            player.canJump = false;
        if(!dialogue.canMove) {
            player.canMove = false;
        }
        activeDialogue = true;
        Debug.Log("Manager" + dialogue.name);
        text.text = "";
        name.text = "";

        if(dialogue.customCamPos == null) {
            camera.SetMode(true);
        } else {
            camera.SetMode(true, dialogue.customCamPos);
        }
        
        ShowMenu();
        avatar.sprite = artemAvatar;
            for(int i = 0; i<dialogue.sentences.Length;i++){
                if(dialogue.sentences[i].StartsWith(" ")){
                    if(dialogue.artemAvatar == null) avatar.sprite = artemAvatar;
                    else avatar.sprite = dialogue.artemAvatar;
                    name.text = "Artem";

                } else {
                    avatar.sprite = dialogue.avatar;
                    name.text = dialogue.name;

                }
                for(int ii=0; ii<dialogue.sentences[i].Length;ii++) {
                    text.text += dialogue.sentences[i][ii];
                    text.text += "_";
                    if(Input.GetButton("Fire1")) {
                        text.text = dialogue.sentences[i] + " ";
                        //break;
                        ii = dialogue.sentences[i].Length;
                    }
                    yield return new WaitForSeconds(letterDelay);
                    text.text = text.text.Remove(text.text.Length-1);
                }
                yield return new WaitForSeconds(0.5f);
                while (Input.GetButton("Fire1"))
                {
                    yield return null;
                }
                spaceText.SetActive(true);
                while (!Input.GetButtonDown("Fire1"))
                {
                    yield return null;
                }
                while (Input.GetButton("Fire1"))
                {
                    yield return null;
                }
                spaceText.SetActive(false);
                text.text = "";
                yield return new WaitForEndOfFrame();
    
            }
        HideMenu(); 
        camera.SetMode(false);    
        activeDialogue = false; 
            player.canJump = player.canJumpstate;
        if(!dialogue.canMove){
            player.canMove = true;  
        }
        OnDialogueEnded?.Invoke(this,EventArgs.Empty);
        
    }

    void ShowMenu() {
        canvasGroup.alpha = 1;
    }

    void HideMenu() {
        canvasGroup.alpha = 0;
    }

}
