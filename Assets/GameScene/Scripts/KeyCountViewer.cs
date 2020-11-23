using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//入手している鍵の総数を表示するためのクラス
public class KeyCountViewer : MonoBehaviour {

    //GameSceneManagerのコンポーネントを入れる
    private GameSceneManager gameSceneManager;

    //Textコンポーネントを入れる
    private Text myKeyCountText;

    //現在表示している鍵の数
    private int shownKeyCount;

	// Use this for initialization
	private void Start () {

        //GameSceneManagerを検索し、GameSceneManagerコンポーネントを取得
        this.gameSceneManager = GameObject.Find("GameSceneManager").GetComponent<GameSceneManager>();

        //Textコンポーネントを取得
        this.myKeyCountText = GetComponent<Text>();

        //表示の更新
        this.UpdateKeyCount();
	}

    public void Update()
    {
        //gamaSceneManagerの鍵の数と表示が一致しないとき
        if(this.gameSceneManager.keyCount != this.shownKeyCount)
        {
            UpdateKeyCount();
        }
    }

    //表示の更新
    private void UpdateKeyCount()
    {
        this.myKeyCountText.text = this.gameSceneManager.keyCount + "/" + this.gameSceneManager.maxKeyCount;
        this.shownKeyCount = this.gameSceneManager.keyCount;
    }
}
