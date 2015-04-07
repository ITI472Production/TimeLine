using UnityEngine;
using System.Collections;

public class GUI_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(Screen.width/4*3-120,Screen.height/2-120,240,220),"");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(Screen.width /2+120,Screen.height/2-20,200,20), "Start Game")) {
			Application.LoadLevel(1);
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(Screen.width /2+120,Screen.height/2+20,200,20), "Credits")) {
			Application.LoadLevel(2);
		}
		// Make the second button.
		if(GUI.Button(new Rect(Screen.width /2+120,Screen.height/2+60,200,20), "Exit")) {
			Application.LoadLevel(2);
		}
	}
}
	