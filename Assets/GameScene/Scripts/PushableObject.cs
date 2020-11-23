using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//クリックで押し出すことのできるオブジェクト
public class PushableObject : MonoBehaviour {

    //GameSceneManagerのコンポーネントを入れる
    private GameSceneManager gameSceneManager;

    //Rigidbodyのコンポーネントを入れる
    private Rigidbody myRigidbody;

	void Start () {

        //GameSceneManagerを検索し、GameSceneManagerコンポーネントを取得
        this.gameSceneManager = GameObject.Find("GameSceneManager").GetComponent<GameSceneManager>();

        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();
	}

    //EventTriggerによりクリック時に呼ばれる
    //MainCameraにアタッチされているPhysicsRaycasterによってEventTriggerが呼ばれます
    public void OnPush()
    {
        Debug.Log("クリックされたオブジェクト" + this.gameObject.name);

        //ClearKinematic関数を呼び出し、isKinematicを解除
        this.ClearKinematic();

        //自分の座標とカメラの座標を減算し、ベクトルを取得
        Vector3 vector = this.transform.position - Camera.main.transform.position;

        //normalized変数を使って向きベクトル（長さを除いた向きだけの情報）を取得
        Vector3 direction = vector.normalized;

        //actionModeが0のとき、向きの+方向へ力を加える
        if (gameSceneManager.actionMode == 0)
        {
            myRigidbody.AddForce(direction * gameSceneManager.power);
        }
        //actionModeが１のとき、向きの-方向へ力を加える
        else if(gameSceneManager.actionMode == 1)
        {
            myRigidbody.AddForce(direction * -gameSceneManager.power);
        }
    }

    //RigidbodyコンポーネントのisKinematic属性を解除する関数
    //isKinematicがtrueの場合、物理挙動を行わない（動かない）ので解除する
    private void ClearKinematic()
    {
        //オブジェクトに親がいる場合：全ての子オブジェクトのKinematicを解除する
        if (this.transform.parent != null)
        {
            //親の子の数だけループ
            for (int i = 0; i < this.transform.parent.childCount; i++)
            {
                //GetChild関数を使用してi番目の子供のRigidbodyを取得しisKinematicをfalseにする
                this.transform.parent.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        //親がいない場合：自分自身のKinematicを解除する
        else
        {
            this.myRigidbody.isKinematic = false;
        }
    }

}
