using UnityEngine;
using System.Collections;

public class camera_control_button : MonoBehaviour {

    int W = Screen.width;
    int H = Screen.height;

    public int FontSize = 15;
    public TextAnchor アンカー = TextAnchor.MiddleCenter;
    public Color TextColor = Color.white;
    public Texture2D BackGround_true;
    public Texture2D BackGround_false;

    GUIStyle style_pos_up;
    GUIStyle style_pos_down;
    GUIStyle style_pos_right;
    GUIStyle style_pos_left;
    GUIStyle style_zoom_in;
    GUIStyle style_zoom_out;
    GUIStyle style_rot_up;
    GUIStyle style_rot_down ;
    GUIStyle style_rot_right;
    GUIStyle style_rot_left;
    GUIStyle style_reset_pos;

    bool pos_up = false;//z+
    bool pos_down = false;
    bool pos_right = false;//x+
    bool pos_left = false;

    bool zoom_in = false;//y-
    bool zoom_out = false;

    bool rot_up = false;//rot_x-
    bool rot_down = false;
    bool rot_right = false;//rot_y-
    bool rot_left = false;

    bool reset_pos = false;

    public game_object MainCamera = new game_object();
    public struct game_object
    {
        public float pos_x;
        public float pos_y;
        public float pos_z;
        public float rot_x;
        public float rot_y;
        public float rot_z;

    }

	// Use this for initialization
	void Start () {
        カメラの初期位置代入();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(MainCamera.pos_x);
	
	}
    void OnGUI()
    {


        style設定();
        ボタン表示();
        if (pos_left) MainCamera.pos_x  -= 0.2f;
        if (pos_right) MainCamera.pos_x += 0.2f;
        if (pos_up) MainCamera.pos_z    += 0.2f;
        if (pos_down) MainCamera.pos_z  -= 0.2f;
        if (rot_left) MainCamera.rot_y  -= 0.2f;
        if (rot_right) MainCamera.rot_y += 0.2f;
        if (rot_up) MainCamera.rot_x    -= 0.2f;
        if (rot_down) MainCamera.rot_x  += 0.2f;
        if (zoom_in) MainCamera.pos_y   -= 0.2f;
        if (zoom_out) MainCamera.pos_y  += 0.2f;

        if (reset_pos) カメラの初期位置代入();



    }

    void style設定()
    {
        var def_style = new GUIStyle();

        def_style.normal.textColor = TextColor;
        def_style.fontSize = FontSize;
        def_style.alignment = アンカー;
        def_style.normal.background = BackGround_false;

        style_pos_up = new GUIStyle(def_style);
        style_pos_down = new GUIStyle(def_style);
        style_pos_right = new GUIStyle(def_style);
        style_pos_left = new GUIStyle(def_style);
        style_zoom_in = new GUIStyle(def_style);
        style_zoom_out = new GUIStyle(def_style);
        style_rot_up = new GUIStyle(def_style);
        style_rot_down = new GUIStyle(def_style);
        style_rot_right = new GUIStyle(def_style);
        style_rot_left = new GUIStyle(def_style);
        style_reset_pos = new GUIStyle(def_style);

        //何故か全部falseになっているので切り替わらない
        if(pos_up)style_pos_up.normal.background = BackGround_true;
        if (pos_down) style_pos_down.normal.background = BackGround_true;
        if (pos_right) style_pos_right.normal.background = BackGround_true;
        if (pos_left) style_pos_left.normal.background = BackGround_true;
        if (zoom_in) style_zoom_in.normal.background = BackGround_true;
        if (zoom_out) style_zoom_out.normal.background = BackGround_true;
        if (rot_up) style_rot_up.normal.background = BackGround_true;
        if (rot_down) style_rot_down.normal.background = BackGround_true;
        if (rot_left) style_rot_left.normal.background = BackGround_true;
        if (rot_right) style_rot_right.normal.background = BackGround_true;
        if (reset_pos) style_reset_pos.normal.background = BackGround_true;
    }

    void ボタン表示()
    {
        var left_x = W / 10;
        var left_y = H * 24 / 30;
        var button_width = W / 10;
        var button_height = H / 20;
        
        var left_x2 = W - left_x-(2*button_width+button_height);

        pos_left = GUI.RepeatButton(new Rect(left_x, left_y + button_width, button_width, button_height), "←", style_pos_left);
        pos_right = GUI.RepeatButton(new Rect(left_x + button_width+button_height, left_y + button_width, button_width, button_height), "→", style_pos_right);
        pos_up= GUI.RepeatButton(new Rect(left_x + button_width, left_y, button_height, button_width), "↑", style_pos_up);
        pos_down = GUI.RepeatButton(new Rect(left_x + button_width, left_y + button_width+button_height, button_height, button_width), "↓", style_pos_down);

        rot_left = GUI.RepeatButton(new Rect(left_x2, left_y + button_width, button_width, button_height), "←", style_rot_left);
        rot_right = GUI.RepeatButton(new Rect(left_x2 + button_width + button_height, left_y + button_width, button_width, button_height), "→", style_rot_right);
        rot_up = GUI.RepeatButton(new Rect(left_x2 + button_width, left_y, button_height, button_width), "↑", style_rot_up);
        rot_down = GUI.RepeatButton(new Rect(left_x2 + button_width, left_y + button_width + button_height, button_height, button_width), "↓", style_rot_down);

        zoom_in = GUI.RepeatButton(new Rect(W/2-button_height*1.2f, left_y + button_width, button_height, button_height), "+", style_zoom_in);
        zoom_out = GUI.RepeatButton(new Rect(W/2+button_height*0.2f, left_y + button_width, button_height, button_height), "-", style_zoom_out);

        reset_pos = GUI.Button(new Rect(W / 2 -button_width, left_y, button_width*2, button_height), "初期位置", style_reset_pos);
    }

    void カメラの初期位置代入()
    {
        MainCamera.pos_x = 0;
        MainCamera.pos_y = 50;
        MainCamera.pos_z = -40;
        MainCamera.rot_x = 60;
        MainCamera.rot_y = 0;
        MainCamera.rot_z = 0;
    }

}
