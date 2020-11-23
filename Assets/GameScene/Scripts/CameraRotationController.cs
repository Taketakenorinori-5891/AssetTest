using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カメラを回転させるためのクラス
public class CameraRotationController : MonoBehaviour {

    //ボタンが押されているか
    private bool isPush = false;

    //回転速度
    private float rotateSpeed;

    //isPuthがtrueの間だけ回転させる
    private void Update()
    {
        //ボタンが押されていれば実行
        if (isPush == true)
        {
            //Y軸を中心に回転
            transform.Rotate(0, rotateSpeed, 0);
        }
    }

    //ボタンが押されたときの処理
    //引数は変数に入れておき、Updateで使う
    public void OnPush(float rotateSpeed)
    {
        //引数の値を変数に保存する
        this.rotateSpeed = rotateSpeed;

        //押されているフラグをtrueに
        isPush = true;
    }

    //ボタンが離されたときの処理
    public void OnUp()
    {
        //押されているフラグをfalseに
        isPush = false;
    }

}
