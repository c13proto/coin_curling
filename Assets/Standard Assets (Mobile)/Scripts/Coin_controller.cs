using UnityEngine;
using System.Collections;

public class Coin_controller : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 prePos;
    private Vector3 currentPos;
    private float counter=0;

    throw_area throw_area_script;
    Statement Statement_script;
    coin_vertical_button coin_vertical_button_script;

    void OnMouseDown()
    {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Statement_script.OnMouseDownPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        
    }

    void OnMouseDrag()
    {
        counter += Time.deltaTime;
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;

        //高さ設定
        if (!coin_vertical_button_script.立てる) currentPosition.y = 0;
        else
        {
            if (this.ToString().IndexOf("one_hundred") != -1) currentPosition.y = 2.26f;
            else if (this.ToString().IndexOf("five_hundred") != -1) currentPosition.y = 2.65f;
            else if (this.ToString().IndexOf("fifty") != -1) currentPosition.y = 2.1f;
            else if (this.ToString().IndexOf("ten") != -1) currentPosition.y = 2.35f;
            else if (this.ToString().IndexOf("one") != -1) currentPosition.y = 2;
            else if (this.ToString().IndexOf("five") != -1) currentPosition.y = 2.2f;
        }
        //ポジションと角度設定
        if (currentPosition.z < -10 && Statement_script.OnMouseDownPosition.z < -10)
        {

            if (coin_vertical_button_script.立てる)
            {
                RotationZ = 90;
            }
            else
            {
                RotationZ = 0;
                RotationX = 180;
            }

            if (coin_vertical_button_script.回転)
            {
                if (coin_vertical_button_script.立てる) RotationY += 0.5f;
                else RotationX += 0.5f;
            }

            transform.position = currentPosition;
        }
        if (counter > 0.05) {
            counter = 0;
            prePos = currentPos;
            currentPos = currentPosition;
        }
        
    }

    void OnMouseUp() {//スローエリア内で投擲する処理.ScreenPointの移動量で速度を決める（拡大表示とかにも対応するため）
        var distance_position = currentPos - prePos;
        var distance_point = Statement_script.currentPoint - Statement_script.prePoint;
        if(throw_area_script.throwable)rigidbody.velocity = distance_position.normalized*distance_point.magnitude*1.75f;
    }
    void Start() {
        //Physics.gravity = new Vector3(0, -15, 0);//重力
        throw_area_script = GameObject.Find("throw_area").GetComponent<throw_area>();
        Statement_script = GameObject.Find("Statement").GetComponent<Statement>();
        coin_vertical_button_script = GameObject.Find("coin_vertical_button").GetComponent<coin_vertical_button>();
    }
    void Update()
    {
        if (PositionY < -100) Destroy(gameObject);//奈落の底に落ちたら削除
        距離を代入();
        
    }
    //ポジションとオイラー角の取得と代入を楽にする
    protected Vector3 Position
    {
        set { this.transform.position = value; }
        get { return this.transform.position; }
    }

    protected float PositionX
    {
        set { Position = new Vector3(value, Position.y, Position.z); }
        get { return Position.x; }
    }

    protected float PositionY
    {
        set { Position = new Vector3(Position.x, value, Position.z); }
        get { return Position.y; }
    }

    protected float PositionZ
    {
        set { Position = new Vector3(Position.x, Position.y, value); }
        get { return Position.z; }
    }
    protected Vector3 Rotation
    {
        set { this.transform.eulerAngles = value; }
        get { return this.transform.eulerAngles; }
    }
    protected float RotationX
    {
        set { Rotation = new Vector3(value, Rotation.y, Rotation.z); }
        get { return Rotation.x; }
    }

    protected float RotationY
    {
        set { Rotation = new Vector3(Rotation.x, value, Rotation.z); }
        get { return Rotation.y; }
    }

    protected float RotationZ
    {
        set { Rotation = new Vector3(Rotation.x, Rotation.y, value); }
        get { return Rotation.z; }
    }
    private void 距離を代入()
    {
        if (this.tag.Equals("P1"))
        {
            if (this.ToString().IndexOf("one_hundred") != -1) Statement_script.p1.one_hundred = Mathf.Sqrt(Mathf.Pow(PositionX, 2) + Mathf.Pow(PositionZ - 20, 2));
            else if (this.ToString().IndexOf("five_hundred") != -1) Statement_script.p1.five_hundred = Mathf.Sqrt(Mathf.Pow(PositionX, 2) + Mathf.Pow(PositionZ - 20, 2));
            else if (this.ToString().IndexOf("fifty") != -1) Statement_script.p1.fifty = Mathf.Sqrt(Mathf.Pow(PositionX, 2) + Mathf.Pow(PositionZ - 20, 2));
            else if (this.ToString().IndexOf("ten") != -1) Statement_script.p1.ten = Mathf.Sqrt(Mathf.Pow(PositionX, 2) + Mathf.Pow(PositionZ - 20, 2));
            else if (this.ToString().IndexOf("five") != -1) Statement_script.p1.five = Mathf.Sqrt(Mathf.Pow(PositionX, 2) + Mathf.Pow(PositionZ - 20, 2));
            else if (this.ToString().IndexOf("one") != -1) Statement_script.p1.one = Mathf.Sqrt(Mathf.Pow(PositionX, 2) + Mathf.Pow(PositionZ - 20, 2));

            
        }
        else if(this.tag.Equals("P2"))
        {
            if (this.ToString().IndexOf("one_hundred") != -1) Statement_script.p2.one_hundred = Mathf.Sqrt(Mathf.Pow(PositionX, 2) + Mathf.Pow(PositionZ - 20, 2));
            else if (this.ToString().IndexOf("five_hundred") != -1) Statement_script.p2.five_hundred = Mathf.Sqrt(Mathf.Pow(PositionX, 2) + Mathf.Pow(PositionZ - 20, 2));
            else if (this.ToString().IndexOf("fifty") != -1) Statement_script.p2.fifty = Mathf.Sqrt(Mathf.Pow(PositionX, 2) + Mathf.Pow(PositionZ - 20, 2));
            else if (this.ToString().IndexOf("ten") != -1) Statement_script.p2.ten = Mathf.Sqrt(Mathf.Pow(PositionX, 2) + Mathf.Pow(PositionZ - 20, 2));
            else if (this.ToString().IndexOf("five") != -1) Statement_script.p2.five = Mathf.Sqrt(Mathf.Pow(PositionX, 2) + Mathf.Pow(PositionZ - 20, 2));
            else if (this.ToString().IndexOf("one") != -1) Statement_script.p2.one = Mathf.Sqrt(Mathf.Pow(PositionX, 2) + Mathf.Pow(PositionZ - 20, 2));
        }
    }

}
