using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//アクションモードの切り替えボタン
public class ActionModeSwitchButton : MonoBehaviour {

    //GameSceneManagerコンポーネントを入れる
    private GameSceneManager gameSceneManager;

    //Imageコンポーネントを入れる
    private Image image;

    //押すボタン画像
    public Sprite pushSprite;

    //引くボタン画像
    public Sprite pullSprite;

    private void Start()
    {
        //GameSceneManagerを検索し、GameSceneManagerコンポーネントを取得
        this.gameSceneManager = GameObject.Find("GameSceneManager").GetComponent<GameSceneManager>();

        //Imageコンポーネントを取得
        this.image = GetComponent<Image>();
    }

    public void OnClick()
    {
        this.gameSceneManager.SwitchActionMode();

        if(this.gameSceneManager.actionMode == 0)
        {
            this.image.sprite = this.pushSprite;
        }else if(this.gameSceneManager.actionMode == 1)
        {
            this.image.sprite = this.pullSprite;
        }
    }
}
