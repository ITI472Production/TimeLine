using UnityEngine;
using System.Collections;

public class CreditsScreenGUI : MonoBehaviour {




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(Screen.width/4*3-140,Screen.height/2-180,300,300),"Credits\n\n\n\nCoding & Art: Maka Gradin \n\nSound: Ryan Downey	\n\nAdrian Wojas\n\n\n\nRutgers ITI\n\nProfessor Bill Crosbie\n\nGame Production Spring 2015");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(Screen.width /2-350,Screen.height/4*3+40,200,40), "Begin Challenge")) {
			Application.LoadLevel("TimeLine-GamePlay");
		}
		
//		// Make the second button.
		if(GUI.Button(new Rect(Screen.width /2-100,Screen.height/4*3+40,200,40), "Credits")) {
						Application.LoadLevel("TimeLine-Credits");
		}
//		// Make the second button.
		if(GUI.Button(new Rect(Screen.width /2+150,Screen.height/4*3+40,200,40), "Exit")) {
			Application.LoadLevel("overworld");
		}
	}
}
