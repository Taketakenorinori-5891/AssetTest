using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ドアを操作するためのクラス
public class DoorController : MonoBehaviour {

    //Faderコンポーネントを入れる（インスペクターから割り当てる）
    public Fader fader;

    //ゲームクリア表示用のオブジェクトを入れる（インスペクターから割り当てる）
    public GameObject gameClearMessage;

    //GameSceneManagerコンポーネントを入れる
    private GameSceneManager gameSceneManager;

    //Animatorコンポーネントを入れる
    private Animator myAnimator;

    //フェードが開始したか
    private bool isFadeStarted;

	// Use this for initialization
	void Start () {

        //GameSceneManagerを検索し、GameSceneManagerコンポーネントを取得
        this.gameSceneManager = GameObject.Find("GameSceneManager").GetComponent<GameSceneManager>();

        //Animatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();
    }

    //EventTriggerによりクリック時に呼ばれる
    //MainCameraにアタッチされているPhysicsRaycasterによってEventTriggerが呼ばれます
    public void OnClickDoor()
    {
        Debug.Log("クリックされたオブジェクト：" + this.gameObject.name);

        //手持ちの鍵の数が総数以上の場合
        if(this.gameSceneManager.keyCount >= gameSceneManager.maxKeyCount)
        {
            //Openのアニメーションを再生
            myAnimator.Play("Open");
        }
        else
        {
            //Lockのアニメーションを再生
            myAnimator.Play("Lock");
        }

    }

    //ゴールがクリックされたときの処理
    public void OnClickGoal()
    {
        //faderにフェード処理を依頼
        fader.FadeIn();
        //フェードフラグをtrueに変更
        isFadeStarted = true;
    }

    private void Update()
    {
        //フェードフラグが開始されていた場合：終了チェック
        if(isFadeStarted == true)
        {
            //フェードが終了しているかチェック
            if(fader.isFading == false)
            {
                //クリアメッセージを表示
                gameClearMessage.SetActive(true);

                //開始フラグをfalseに
                isFadeStarted = false;
            }
        }
    }

}
