using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//自動で回転させるためのスクリプト
public class AutoRotateObject : MonoBehaviour {

    // 回転速度
    public Vector3 m_rotateSpeed = new Vector3(0,1,0);

    // Update is called once per frame
    void Update()
    {
        //回転
        this.transform.Rotate(m_rotateSpeed);
    }
}
