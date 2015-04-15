using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	int goodGuesses;

	// Use this for initialization
	void Start () {
	
	}

	public void CorrectAnswer() {
		goodGuesses++;
	}


	// Update is called once per frame
	void Update () {
	
	}
	
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}


}
