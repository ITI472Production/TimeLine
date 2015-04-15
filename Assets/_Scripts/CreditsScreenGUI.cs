using UnityEngine;
using System.Collections;

public class CreditsScreenGUI : MonoBehaviour {

	ScoreKeeper sk;
	GameObject scores;

	string correctGuesses;

	// Use this for initialization
	void Start () {
		scores = GameObject.Find("ScoreKeeper");
		sk = scores.GetComponent<ScoreKeeper>();

		correctGuesses = sk.goodGuesses.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	}
	

	void OnGUI () {
		GUI.color = Color.black;
		GUI.backgroundColor = Color.clear;

		// Make a background box
		GUI.Box(new Rect(Screen.width/4*3-140,Screen.height/2-180,300,300),"Credits\n\nCoding & Art: Maka Gradin\nSound: Ryan Downey\nAdrian Wojas\n\nRutgers University\nInformation Technology and Informatics\n\nGame Production\nSpring 2015\nProfessor Bill Crosbie");
		
		GUI.color = Color.red;

		GUI.Box(new Rect(Screen.width/4*3-140,Screen.height/2+40,300,300),"You successfully submitted\n"+ correctGuesses +" event!");

		// Button 1 - loads the actual game.
		if(GUI.Button(new Rect(Screen.width /2-350,Screen.height/4*3+40,200,40), "Begin Challenge")) {
			Application.LoadLevel("TimeLine-GamePlay");
			cc.badGuesses = 0;
			cc.goodGuesses = 0;
			cc.Reset();
		}
		
//		// Button 2 - loads the credits.
		if(GUI.Button(new Rect(Screen.width /2-100,Screen.height/4*3+40,200,40), "Title Screen")) {
			Application.LoadLevel("TimeLine-GameLoad");
		}
//		// Button 3 - returns to overworld.
		if(GUI.Button(new Rect(Screen.width /2+150,Screen.height/4*3+40,200,40), "Exit")) {
			Application.LoadLevel("overworld_01");
		}
	}
}

