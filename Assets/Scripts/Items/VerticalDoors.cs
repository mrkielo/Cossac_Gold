using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalDoors : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float range;
    [SerializeField] float openTime;
    [SerializeField] Transform parentTransform;
    float yScale;
    float target;
    float posTarget;
    float yPos;
    float progress = 0;
    bool opening = false;

    void Awake()
    {
        yScale = transform.localScale.y;
        yPos = transform.position.y;
        Close();
    }

    // Update is called once per frame
    void Update()
    {
        bool isPlayerInRange = Physics2D.OverlapCircle(parentTransform.position,range,LayerMask.GetMask("Player"));

        if(isPlayerInRange && !opening) Open();
        if(!isPlayerInRange && opening) Close();

        Lerp();
    }

    void Open() {
        opening = true;
        target = 0;
        progress = 0;
        posTarget = yPos + transform.localScale.y/2;
    }

    void Close() {
        progress=0;
        opening = false;
        target = yScale;
        posTarget = yPos;
    }

    void Lerp() {
       transform.localScale =new Vector2(transform.localScale.x,Mathf.Lerp(transform.localScale.y,target,progress/openTime));
       transform.position = new Vector2(transform.position.x,Mathf.Lerp(transform.position.y,posTarget,progress/openTime));
       progress += Time.deltaTime;
    }
}
