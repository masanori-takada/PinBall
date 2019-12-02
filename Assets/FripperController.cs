using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    HingeJoint myHingejoint;
    float defaultAngle = 20;
    float flickAngle = -20;
    //アクセス修飾子を省略すると自動的にprivate修飾子が指定されます。

    //自作のSetAngle関数は、バネの力で戻ろうとするfripperの戻る位置を、angle引数として代入している
    void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingejoint.spring;
        //jointSprという変数は、ヒンジジョイントのスプリングの力を定義する
        jointSpr.targetPosition = angle;
        //スプリングが戻ろうとする目標位置は、引数のangle
        this.myHingejoint.spring = jointSpr;
        //定義したスプリングの力に、上記のangleを満足するジョイントスプリングを代入している
    }

    void Start()
    {
        this.myHingejoint = GetComponent<HingeJoint>();
        //fripperにアタッチしたHingeJointコンポーネントを取得する
        SetAngle(this.defaultAngle);
        //最初のアングルは、初期位置のdefaultAngle
    }

    void Update()
    {
        //tagの名前を調べることで、fripperを識別している
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x < 0 && tag == "LeftFripperTag")
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        SetAngle(this.flickAngle);
                        break;

                    case TouchPhase.Ended:
                        SetAngle(this.defaultAngle);
                        break;
                }
                
            }
            
        }


        //if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        //{
        //    SetAngle(this.flickAngle);
        //}

        //if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        //{
        //    SetAngle(this.defaultAngle);
        //}

        //if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        //{
        //    SetAngle(this.defaultAngle);
        //}
    }

    
}