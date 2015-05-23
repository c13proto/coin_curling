using UnityEngine;
using System.Collections;

public class coin_vertical_button : MonoBehaviour {

    int W = Screen.width;
    int H = Screen.height;

    public bool 立てる = false;
    public bool 回転 = false;

    public int FontSize = 15;
    public TextAnchor アンカー = TextAnchor.MiddleCenter;
    public Color TextColor = Color.white;
    public Texture2D BackGround_true;
    public Texture2D BackGround_false;
    // Use this for initialization
    void Start()
    {
        立てる = false;
        回転 = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {
        var style1 = new GUIStyle();
        var style2 = new GUIStyle();

        if(立てる)style1.normal.background = BackGround_true;
        else style1.normal.background = BackGround_false;
        style1.normal.textColor = TextColor;
        style1.fontSize = FontSize;
        style1.alignment = アンカー;

        if (回転) style2.normal.background = BackGround_true;
        else style2.normal.background = BackGround_false;
        style2.normal.textColor = TextColor;
        style2.fontSize = FontSize;
        style2.alignment = アンカー;

        立てる = GUI.Toggle(new Rect(W * 7 / 10, H * 3 / 30, W / 5, H / 30), 立てる, "立てる", style1);
        回転 = GUI.Toggle(new Rect(W * 7 / 10, H * 4 / 30, W / 5, H / 30), 回転, "回転", style2);
    }
}
