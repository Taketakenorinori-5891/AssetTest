using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//パスワード入力用のキャンバスを扱うクラス
public class PasswordCanvasController : MonoBehaviour {

    //結果表示用のテキストコンポーネント（インスペクターから割り当てる）
    public Text resultText;

    //パスワード解除時に開くドアの参照
    public GameObject boxDoor;

    //時間でUIを閉じるためのタイマー
    private float closeTimer = 0;

    //すでに開いているかフラグ
    private bool isOpened = false;    

    //パスワード入力用のキャンバスを表示する
    public void OpenCanvas()
    {
        Debug.Log("OpenCanvasが呼ばれた");

        //まだ開いていなければ実行
        if(isOpened == false)
        {
            //テキストを更新
            resultText.text = "パスワードを入力してエンターキーを押してください";

            //テキストの色を白に
            resultText.color = Color.white;

            //キャンバスをアクティブにする
            this.gameObject.SetActive(true);
        }
    }

    //パスワード入力用のキャンバスを非表示にする
    public void CloseCanvas()
    {
        //キャンバスを非アクティブにする
        this.gameObject.SetActive(false);
    }

    //文字入力が終わったときに呼ばれる関数
    public void EditEnd(string enteredText)
    {
        Debug.Log(enteredText);

        //パスワードが一致していた場合
        if(enteredText == "TECHACADEMY" || enteredText == "techacademy")
        {
            //テキストを変更
            resultText.text = "パスワード一致！";
            //テキストの色を水色に
            resultText.color = Color.cyan;
            //ドアを削除
            Destroy(boxDoor);
            //開いているフラグをtrueに
            isOpened = true;
        }
        //パスワードが不一致の場合
        else
        {
            //テキストを変更
            resultText.text = "パスワード不一致";
            //テキストの色を赤に
            resultText.color = Color.red;
        }

        //2秒後に閉じるために2を代入
        closeTimer = 2;
    }

    private void Update()
    {

        //closeTimerが0でない間実行
        if(closeTimer > 0)
        {
            //closeTimerを減らす
            closeTimer -= Time.deltaTime;

            //closeTimerが残っていない場合はキャンバスを閉じる
            if(closeTimer <= 0)
            {
                //CloseCanvasを呼び出す
                CloseCanvas();
            }
        }
    }
}
