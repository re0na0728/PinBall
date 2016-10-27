using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    //ポイントを表示するテキスト
    private GameObject pointText;

    //オブジェクトに衝突加算されるポイント
    private int point;

    //ポイントの合計値
    private int sumPoint = 0;

	// Use this for initialization
	void Start () {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のpointTextオブジェクトを取得
        this.pointText = GameObject.Find("PointText");
	
	}
	
	// Update is called once per frame
	void Update () {
        //ボールが画面外に出た場合
        if(this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
	
	}

    void OnCollisionEnter(Collision other)
    {
        //衝突したオブジェクトによって加算されるポイントを変える
        if(other.gameObject.tag == "SmallStarTag")
        {
            point = 10;
        }else if(other.gameObject.tag == "LargeStarTag")
        {
            point = 20;
        }else if(other.gameObject.tag == "SmallCloudTag")
        {
            point = 30;
        }else if(other.gameObject.tag == "LargeCloudTag")
        {
            point = 40;
        }

        //ポイントの合計値を加算する
        sumPoint += point;

        //PointTextにポイントを表示
        this.pointText.GetComponent<Text>().text = "Point:" + sumPoint;

    }
}
