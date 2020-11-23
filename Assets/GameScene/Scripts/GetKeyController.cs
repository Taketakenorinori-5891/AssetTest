using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//鍵を取得するためのクラス
public class GetKeyController : MonoBehaviour {

    //GameSceneManagerコンポーネントを入れる
    private GameSceneManager gameSceneManager;

    // Use this for initialization
    void Start()
    {
        //GameSceneManagerを検索し、GameSceneManagerコンポーネントを取得
        this.gameSceneManager = GameObject.Find("GameSceneManager").GetComponent<GameSceneManager>();
    }

    //EventTriggerによりクリック時に呼ばれる
    //MainCameraにアタッチされているPhysicsRaycasterによってEventTriggerが呼ばれます
    public void OnGetKey()
    {
        //GameSceneManagerのKeyCountを1増やす
        gameSceneManager.keyCount++;

        //Keyを削除
        Destroy(gameObject);
    }

	
}
