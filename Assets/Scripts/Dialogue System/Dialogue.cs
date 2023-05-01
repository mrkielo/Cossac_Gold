using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    [TextArea(3,10)]
    public string[] sentences;
    public Sprite avatar;
    public Sprite artemAvatar;
    public string name;
    public bool canMove;
    public Transform customCamPos;

}
