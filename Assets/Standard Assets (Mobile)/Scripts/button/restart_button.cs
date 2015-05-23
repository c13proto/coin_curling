using UnityEngine;
using System.Collections;

public class restart_button : MonoBehaviour {
    int W = Screen.width;
    int H = Screen.height;

    public string Text = "Restart";
    public int FontSize=15;
    public TextAnchor アンカー = TextAnchor.MiddleCenter;
    public Color TextColor = Color.white;
    public Texture2D BackGround;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        var style = new GUIStyle();
        style.normal.background = BackGround;
        style.normal.textColor = TextColor;
        style.fontSize = FontSize;
        style.alignment = アンカー;

        if (GUI.Button(new Rect(W * 7 / 10, H / 30, W / 5, H / 25), Text,style))
            Application.LoadLevel("base");
    }
}
