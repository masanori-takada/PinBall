using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour
{
    Material myMaterial;

    float minEmission = 0.3f;
    //emissionの最小値
    float magEmission = 2.0f;
    //emissionの強度
    int degree = 0;
    //角度。sin関数の中で使用
    int speed = 10;
    //発光速度

    Color defaultColor = Color.white;
    //このColor.white　を書く理由は、
    //定義した変数には、必要なくても初期値を代入しておいた方が、上述の他の変数とも揃って、見やすい


    void OnCollisionEnter(Collision other)
    {
        this.degree = 180;
        //衝突した時の初期角度を180と設定。
    }


    void Start()
    {
        //タグによって光らせる色を変える
        if (tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;
        }

        else if (tag == "LargeStarTag")
        {
            this.defaultColor = Color.yellow;
        }

        if (tag == "SmallCloudTag" || tag == "LargeCloudTag") 　 //||　は　またはの意味

        {
            this.defaultColor = Color.cyan;
        }

        this.myMaterial = GetComponent<Renderer>().material;
        //Renderer　は、オブジェクトを描画するためのメイン処理＆データ管理
        //各オブジェクトにアタッチしているMaterialを取得

        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);
        //各オブジェクトの、EmissionColorの最初の色を、this.defaultColor * minEmission　に設定
        //最初はdefaultColorの０．３掛けにより、暗めに設定しておく
    }

    void Update()
    {
        //光らせる強度を計算する
        if (this.degree >= 0)
        {
            Color emissionColor
                = this.defaultColor
                * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);
            //光らせる強度を計算する
            //this.degree * Mathf.Deg2Rad　はラジアン変換

            myMaterial.SetColor("_EmissionColor", emissionColor);
            //各マテリアルのEmissionに、emissionColorを設定する。

            this.degree -= this.speed;
            //角度を小さくしていくことで、光が消えていく。
            //衝突がないときは、初期値が０のときで、どんどんマイナスになるため、このifは発動せず何も起こらない
            //衝突したときは、初期値が１８０となるため、ifが発動する
        }
    }


}
