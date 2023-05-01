using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PlatformEffector2D effector;

    private void Start() {
        effector = GetComponent<PlatformEffector2D>();

    }

    private void Update() {
        if(Input.GetAxisRaw("Vertical")<0){
            effector.rotationalOffset = 180;
        } else {
            effector.rotationalOffset = 0;
        }
    }

}
