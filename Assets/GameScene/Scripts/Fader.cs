using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

    public bool isFading = false;

    private Image image;

    private float fadeValue;

    private float fadeSpeed = 0.02f;

    public void FadeIn()
    {
        isFading = true;
        image.enabled = true;
        Color color = image.color;
        color.a = 0;
        image.color = color;
        fadeValue = +fadeSpeed;
    }

    public void FadeOut()
    {
        isFading = true;
        image.enabled = true;
        Color color = image.color;
        color.a = 1;
        image.color = color;
        fadeValue = -fadeSpeed;
    }


	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        FadeOut();
	}
	
	// Update is called once per frame
	void Update () {
		if(isFading == true)
        {
            Color color = image.color;
            color.a += fadeValue;
            image.color = color;

            if(color.a < 0)
            {
                isFading = false;
                image.enabled = false;
            }

            if(color.a > 1)
            {
                isFading = false;
            }
        }
	}
}
