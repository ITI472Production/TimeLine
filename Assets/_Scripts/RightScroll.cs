using UnityEngine;
using System.Collections;

public class RightScroll : MonoBehaviour {

	CardController cc;
	
	GameObject controlCube;

	void OnMouseUp() {
		cc.ScrollTimeline(1);

	}

	// Use this for initialization
	void Start () {
		controlCube = GameObject.Find("Card Controller");
		cc = controlCube.GetComponent<CardController>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
