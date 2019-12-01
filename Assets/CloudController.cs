using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    float minimum = 1.0f;
    float magspeed = 10.0f;
    float magnification = 0.07f;
    //アクセス修飾子を省略すると自動的にprivate修飾子が指定されます。

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.localScale = new Vector3
            (
            this.minimum + Mathf.Sin(Time.time * this.magspeed) * this.magnification,
            this.transform.localScale.y,
            this.minimum + Mathf.Sin(Time.time * this.magspeed) * this.magnification
            );
        //localScaleは、Vector3型の拡大率
        //yの拡大率は変化ないので、オブジェクト自身の大きさを指定している
        //x、zの拡大にて、sin(t*w)*拡大係数　にて、0.93〜1.07倍している
        //Time.timeは、ゲーム開始からの時間を取得する
    }
}
