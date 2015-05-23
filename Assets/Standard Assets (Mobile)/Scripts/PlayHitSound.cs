using UnityEngine;
using System.Collections;

public class PlayHitSound : MonoBehaviour {
    public AudioClip sound;
    public float volume = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag.ToString().IndexOf("coin") != -1)
            AudioSource.PlayClipAtPoint(sound, transform.position, volume);
    }
}
