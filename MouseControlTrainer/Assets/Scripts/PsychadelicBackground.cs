using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychadelicBackground : MonoBehaviour {

    Camera cam = null;
    Color backColor = Color.red;

    [SerializeField]
    float multiplier = 1.0f;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if(backColor.r >= 1.0f && backColor.g < 1.0f && backColor.b <= 0.0f)
        {
            backColor.g += Time.deltaTime * multiplier;
        }
        else if(backColor.g >= 1.0f && backColor.r > 0.0f)
        {
            backColor.r -= Time.deltaTime * multiplier;
        }
        else if(backColor.g >= 1.0f && backColor.b < 1.0f)
        {
            backColor.b += Time.deltaTime * multiplier;
        }
        else if(backColor.b >= 1.0f && backColor.g > 0.0f)
        {
            backColor.g -= Time.deltaTime * multiplier;
        }
        else if(backColor.b >= 1.0f && backColor.r < 1.0f)
        {
            backColor.r += Time.deltaTime * multiplier;
        }
        else if(backColor.r >= 1.0f && backColor.b > 0.0f)
        {
            backColor.b -= Time.deltaTime * multiplier;
        }
        cam.backgroundColor = new Color(backColor.r*0.5f+0.25f, backColor.g*0.5f + 0.25f, backColor.b*0.5f + 0.25f);
	}
}
