using UnityEngine;
using System.Collections;

public class camera_operation : MonoBehaviour {

    camera_control_button camera_control_button_script;
	// Use this for initialization
	void Start () {
        camera_control_button_script = GameObject.Find("camera_control_button").GetComponent<camera_control_button>();
	}
	
	// Update is called once per frame
	void Update () {
        if (camera_control_button_script != null)
        {
            PositionX = camera_control_button_script.MainCamera.pos_x;
            PositionY = camera_control_button_script.MainCamera.pos_y;
            PositionZ = camera_control_button_script.MainCamera.pos_z;
            RotationX = camera_control_button_script.MainCamera.rot_x;
            RotationY = camera_control_button_script.MainCamera.rot_y;
            RotationZ = camera_control_button_script.MainCamera.rot_z;
        }
	
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
}
