using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Statement : MonoBehaviour {

    public Vector3 screenPoint;
    public Vector3 offset;
    public Vector3 prePoint;
    public Vector3 currentPoint;
    public float counter = 0;
    public Vector3 OnMouseDownPosition;

    public coins p1;
    public coins p2;

    public List<float> SortList = new List<float>();

    public struct coins
    {
        public float one;
        public float five;
        public float ten;
        public float fifty;
        public float one_hundred;
        public float five_hundred;
    }


    void OnMouseDrag()
    {


    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ScreenPoint取得();
        距離をソートする();
        //Debug.Log(p2.five_hundred);
	}

    private void ScreenPoint取得()
    {
        counter += Time.deltaTime;
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        if (counter > 0.05)
        {
            counter = 0;
            prePoint = currentPoint;
            currentPoint = currentScreenPoint;

        }
    }

    void 距離をソートする()
    {
        SortList.Clear();
        var preSort = new float[]{p1.one,p1.five,p1.ten,p1.fifty,p1.one_hundred,p1.five_hundred,
                            p2.one,p2.five,p2.ten,p2.fifty,p2.one_hundred,p2.five_hundred};

        for (int i = 0; i < preSort.Length; i++) SortList.Add(preSort[i]);
        SortList.Sort();
    }
}
