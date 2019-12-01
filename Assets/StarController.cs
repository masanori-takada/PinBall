using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    float rotspeed = 1.0f;
    //回転速度
    //また、アクセス修飾子を省略すると自動的にprivate修飾子が指定されます。

    void Start()
    {
        this.transform.Rotate(0, Random.Range(0, 360), 0);
        //回転角度の初期値を定義
    }

    void Update()
    {
        this.transform.Rotate(0, this.rotspeed, 0);
        //回転速度＝1コマあたりの移動距離
    }
}
