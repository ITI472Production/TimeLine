using UnityEngine;
using System.Collections;

public class LoadScreenGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI () {
		// Make a background box
		//GUI.Box(new Rect(Screen.width/4*3-120,Screen.height/2-120,240,220),"");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(Screen.width /2+140,Screen.height/2-100,200,40), "Begin Challenge")) {
			Application.LoadLevel("TimeLine-GamePlay");
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(Screen.width /2+140,Screen.height/2-20,200,40), "Credits")) {
			Application.LoadLevel("TimeLine-Credits");
		}
		// Make the second button.
		if(GUI.Button(new Rect(Screen.width /2+140,Screen.height/2+60,200,40), "Exit")) {
			Application.LoadLevel("overworld");
		}
	}
}
