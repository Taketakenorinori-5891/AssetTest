using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ゲームシーンを管理するクラス
public class GameSceneManager : MonoBehaviour {

    //オブジェクトクリック時の挙動を表す変数
    //0の場合:押す　1の場合：引く
    public int actionMode;

    //押す、引く力
    public float power = 100;

    //現在入手している鍵の数
    public int keyCount;

    //シーン内に配置されている鍵の数
    public int maxKeyCount;


	// Use this for initialization
	void Start () {
        //Keyのタグを含むオブジェクトをすべて検索し、配列の要素数をmaxKeyCountに代入する
        maxKeyCount = GameObject.FindGameObjectsWithTag("Key").Length;
	}

    //actionModeを変更する関数
    public void SwitchActionMode()
    {
        //actionModeが0（押すモード）の場合、１（引くモード）に変更
        if(actionMode == 0)
        {
            actionMode = 1;

        }
        //actionModeが1（引くモード）の場合、0（押すモード）に変更
        else if (actionMode == 1)
        {
            actionMode = 0;
        }
        //それ以外の場合はエラー
        else
        {
            Debug.LogError("ActionMode" + actionMode + "は作られていません");
        }
    }
	
	// Update is called once per frame
	void Update () {

        /*

        //デバッグ用　エディタ上であれば実行
        if (Application.isEditor == true)
        {
            //スペースキーが押されたら鍵の数を増やす
            if (Input.GetKeyDown(KeyCode.Space))
            {
                keyCount++;
            }
        }

        */
	}
}
