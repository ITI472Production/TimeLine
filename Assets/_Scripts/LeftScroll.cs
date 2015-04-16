using UnityEngine;
using System.Collections;

public class LeftScroll : MonoBehaviour {

	CardController cc;
	
	GameObject controlCube;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		controlCube = GameObject.Find("Card Controller");
		cc = controlCube.GetComponent<CardController>();
		audio = GetComponentInParent<AudioSource>();
		
	}

	void OnMouseUp() {
		cc.ScrollTimeline(-1);
		audio.PlayOneShot(audio.clip, 1F);
	}


	// Update is called once per frame
	void Update () {
	
	}
}
