using UnityEngine;
using System.Collections;

public class throw_area : MonoBehaviour {
    public bool throwable = false;
	// Use this for initialization
	void Start () {
        collider.isTrigger = true;
        throwable = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerStay(Collider other)
    {
        throwable = true;
    }
    private void OnTriggerExit(Collider other)
    {
        throwable = false;
    }
}
