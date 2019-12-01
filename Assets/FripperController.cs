using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    HingeJoint myHingejoint;
    float defaultAngle = 20;
    float flickAngle = -20;
    //アクセス修飾子を省略すると自動的にprivate修飾子が指定されます。


    void Start()
    {
        this.myHingejoint = GetComponent<HingeJoint>();
        //fripperにアタッチしたHingeJointコンポーネントを取得する
        SetAngle(this.defaultAngle);
        //自作のSetAngle関数は、バネの力で戻ろうとするfripperの戻る位置を、angle引数として代入している
    }

    void Update()
    {
        //tagの名前を調べることで、fripperを識別している
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }

    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingejoint.spring;
        //jointSprという変数は、ヒンジジョイントのスプリングの力を定義する
        jointSpr.targetPosition = angle;
        //バネが戻ろうとする目標位置は、引数のangle
        this.myHingejoint.spring = jointSpr;
        //定義したスプリングの力に、上記のangleを満足するジョイントスプリングを代入している
    }
}