using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour {

    public Fader fader;

    bool isFading = false;

    public void Retry()
    {
        isFading = true;
        fader.FadeIn();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isFading == true)
        {
            if(fader.isFading == false)
            {
                SceneManager.LoadScene("GameScene");
            }
        }
	}
}
