using UnityEngine;
using System.Collections;

public class RightScroll : MonoBehaviour {

	CardController cc;
	
	GameObject controlCube;
	AudioSource audio;

	void OnMouseUp() {
		cc.ScrollTimeline(1);
		audio.PlayOneShot(audio.clip, 1F);

	}

	// Use this for initialization
	void Start () {
		controlCube = GameObject.Find("Card Controller");
		cc = controlCube.GetComponent<CardController>();
		audio = GetComponentInParent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
