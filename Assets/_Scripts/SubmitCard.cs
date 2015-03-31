using UnityEngine;
using System.Collections;

public class SubmitCard : MonoBehaviour {

	CardController cc;
	
	GameObject controlCube;

	void OnMouseUp() {
		if(CardZoomTemplate(Clone)) {
			cc.AddToTimeline();
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
