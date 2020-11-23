using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテムを指定箇所に複数個生成するボタン用コントローラー
public class GenerateButtonController : MonoBehaviour {

    //落下させるKey（インスペクターから割り当てる）
    public Rigidbody key;

    //生成する場所（インスペクターから割り当てる）
    public Transform generatePosition;

    //生成するオブジェクト（インスペクターから割り当てる）
    public GameObject generatePrefab;

    //生成個数
    public int generateCount = 8;

    //GameSceneManagerコンポーネントを入れる
    private GameSceneManager gameSceneManager;

    //生成場所をずらす幅
    private float randomOffset = 1;

    //すでに押されているか
    private bool isPushed = false;

    private void Start()
    {
        //GameSceneManagerを検索し、GameSceneManagerコンポーネントを取得
        this.gameSceneManager = GameObject.Find("GameSceneManager").GetComponent<GameSceneManager>();
    }

    //EventTriggerによりクリック時に呼ばれる
    //MainCameraにアタッチされているPhysicsRaycasterによってEventTriggerが呼ばれます
    public void Generate()
    {
        //押すモードであれば実行
        if(this.gameSceneManager.actionMode == 0 && this.isPushed == false)
        {
            //生成個数だけループ
            for (int i = 0; i < this.generateCount; i++)
            {
                //生成座標はgeneratePositionからランダムにずれた場所
                Vector3 instancePosition = generatePosition.position;
                instancePosition.x += Random.Range(-randomOffset, randomOffset);
                instancePosition.y += Random.Range(-randomOffset, randomOffset);
                instancePosition.z += Random.Range(-randomOffset, randomOffset);

                //生成処理
                Instantiate(generatePrefab, instancePosition, generatePrefab.transform.rotation);
            }

            //鍵を落下させるために位置制限を解除
            key.constraints = RigidbodyConstraints.None;

            //ボタンをひっこめるためにスケールを変更
            Vector3 pushedScale = transform.localScale;
            pushedScale.y -= 0.2f;
            this.transform.localScale = pushedScale;

            //押されたフラグをtrueに
            this.isPushed = true;
        }

    }


}
