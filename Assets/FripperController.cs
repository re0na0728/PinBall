using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour {
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoynt;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

	// Use this for initialization
	void Start () {
        //HinjiJointコンポーネント取得
        this.myHingeJoynt = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        setAngle(this.defaultAngle);
	
	}
	
	// Update is called once per frame
	void Update () {
        //左矢印キーを押した時左フリッパーを動かす
        if(Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            setAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if(Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            setAngle(this.flickAngle);
        }

        //矢印キーが離されたときフリッパーを元に戻す
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            setAngle(this.defaultAngle);
        }

        //画面をクリックしたときにフリッパーを動作させる
        if (Input.GetMouseButton(0))
        {
            //画面中央より左側がクリックされたとき
            if (Input.mousePosition.x < Screen.width / 2 && tag == "LeftFripperTag")
            {
                setAngle(this.flickAngle);
            }
            //画面中央より右側がクリックされたとき
            if (Input.mousePosition.x >= Screen.width / 2 && tag == "RightFripperTag")
            {
                setAngle(this.flickAngle);
            }
        }
        //クリックが離されたときフリッパーを元に戻す
        if (Input.GetMouseButtonUp(0))
        {
            setAngle(this.defaultAngle);
        }



    }

    //フリッパーの傾きを設定
    public void setAngle (float angle)
    {
        JointSpring jointSpr = this.myHingeJoynt.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoynt.spring = jointSpr;
    }
}
