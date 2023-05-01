using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField] CanvasGroup group;
    float target;
    float time = 0;
    float value;
    float progress = 0;
    // Start is called before the first frame update
    void Awake()
    {
        target = group.alpha;
        // if(group == null) {
        //     group = GetComponent<CanvasGroup>();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if(target!=group.alpha) Lerp();
    }

	public void In(float t) {
		value = 0;
		target = 1;
		time = t;
		progress = 0;
		group.alpha = value;
    }

    public void Out(float t) {
        value = 1;
        target = 0;
        time = t;
        progress = 0;
        group.alpha = value;
    }
    
    void Lerp() {
        if(progress<time) {
            group.alpha = Mathf.Lerp(value,target,progress/time);
            progress += Time.deltaTime;
        } else {
            group.alpha = target;
        }
    }
}
