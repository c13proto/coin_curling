using UnityEngine;
using System.Collections;

public class P2 : MonoBehaviour {

    int W = Screen.width;
    int H = Screen.height;

    Statement Statement_script;
    // Use this for initialization
    void Start()
    {
        Statement_script = GameObject.Find("Statement").GetComponent<Statement>();
        guiText.pixelOffset = new Vector2(W*12 / 30, H * 39 / 40);

    }

    // Update is called once per frame
    void Update()
    {
        if (Statement_script != null)
        {
            float one = Statement_script.p2.one;
            float five = Statement_script.p2.five;
            float ten = Statement_script.p2.ten;
            float fifty = Statement_script.p2.fifty;
            float one_hundred = Statement_script.p2.one_hundred;
            float five_hundred = Statement_script.p2.five_hundred;

            guiText.text = "Player2" + "\n"
                + "1円玉    :" + one.ToString("f2") + 順位を返す(one)+"\n"
                + "5円玉    :" + five.ToString("f2") + 順位を返す(five) + "\n"
                + "10円玉  :" + ten.ToString("f2") + 順位を返す(ten) + "\n"
                + "50円玉  :" + fifty.ToString("f2") + 順位を返す(fifty) + "\n"
                + "100円玉:" + one_hundred.ToString("f2") + 順位を返す(one_hundred) + "\n"
                + "500円玉:" + five_hundred.ToString("f2") + 順位を返す(five_hundred) + "\n";

        }
    }
    string 順位を返す(float distance)
    {

        string 順位 = (Statement_script.SortList.IndexOf(distance) + 1).ToString();

        return "(" + 順位 + ")";
    }
}
