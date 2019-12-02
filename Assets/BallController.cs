using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallController : MonoBehaviour
{
    float visiblePosZ = -6.5f;
    GameObject gameOverText;
    GameObject pointText;
    float point = 0;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.point += 10.0f;
        }

        if (other.gameObject.tag == "LargeStarTag")
        {
            this.point += 20.0f;
        }

        if (other.gameObject.tag == "SmallCloudTag")
        {
            this.point += 30.0f;
        }

        if (other.gameObject.tag == "LargeCloudTag")
        {
            this.point += 50.0f;
        }

    }



    void Start()
    {
        //UIを拾ってくる
        this.gameOverText = GameObject.Find("GameOverText");
        this.pointText = GameObject.Find("PointText");
    }

    void Update()
    {
        this.pointText.GetComponent<Text>().text = point.ToString() + "point";

        //ボールのZ座標が−６．５を下回ると、UIにゲームオーバーの表示を指示。
        if (this.transform.position.z < this.visiblePosZ)
        {
            this.gameOverText.GetComponent<Text>().text = "Game Over";
        }

    }
}
