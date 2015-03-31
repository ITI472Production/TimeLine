﻿//Many hints obtained from watching "Unity Blackjack Making a Card"
// video series on YouTube:  https://youtu.be/D0GOgSkHahI

//This is attached to the Card Controller Game Object and controls card spawning.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardController : MonoBehaviour {

	public int cardIndex;
//	int[] years = new int[] {1766,1795,1809,1812,1825,1869,1873,1918,1921,1924,1932,1934,1943,1945,1946,1950,1952,1961,1963,1966,1969,1971,1972,1989,1995,1998,1999,2006,2007,2009,2012,2013};
	List<int> yearlist = new List<int> {1766,1795,1809,1812,1825,1869,1873,1918,1921,1924,1932,1934,1943,1945,1946,1950,1952,1961,1963,1966,1969,1971,1972,1989,1995,1998,1999,2006,2007,2009,2012,2013};
	List<int> listOfAvailableDates = new List<int> {1766,1795,1809,1812,1825,1869,1873,1918,1921,1924,1932,1934,1943,1945,1946,1950,1952,1961,1963,1966,1969,1971,1972,1989,1995,1998,1999,2006,2007,2009,2012,2013};
	List<int> cardsOnTimeline = new List<int> {};
//	List<int> shuffledyears;
	List<int> handOfCards = new List<int> {};
	public Card CardTemplate;
	public Card CardTimelineTemplate;
	public Card CardZoomTemplate;
	public Texture cardback;
	//Arrays of textures for images.
		public Texture[] cardhints; 	public Texture[] cardreveals;
	//The selected card placeholder
		GameObject selectedCard;
	//Timeline place holders
		GameObject TL1; GameObject TL2;	GameObject TL3;	GameObject TL4;

	int firstTimelineCard = 0;

	// Use this for initialization
	void Start () {
		//STEP 1: Grab 4 Cards for Timeline start
		SetupTimeline();
		//STEP 2: Shuffle the remaining available Cards!
		listOfAvailableDates = ShuffleCards(listOfAvailableDates);
		//STEP 3: Shuffle out 5 Cards from the shuffledyears
		SetupHand ();
		DealCard ();
		CardtoTimeline ();
	}

	//Step 1!
	void SetupTimeline(){
		Debug.Log("SetupTimeline start - number of available cards = "+ listOfAvailableDates.Count);
		for (int i = 0; i < 4; i++ )
		{
			//pick a random date from the List
			int r = Random.Range(i, listOfAvailableDates.Count);
			//save what is in the randomly slots slot in the current slot
			cardsOnTimeline.Add(listOfAvailableDates[r]);
			//save what was in the current slot in the randomly chosen slot
			listOfAvailableDates.RemoveAt(r);
			Debug.Log(cardsOnTimeline[i]+"added to Timeline list and removed from available dates");
		}
		Debug.Log("SetupTimeline end - number of available cards = "+ listOfAvailableDates.Count);
		SortTimeline();
	}

	//STEP 2!
	List<int> ShuffleCards(List<int> listOfAvailableDates) {
		Debug.Log ("Shuffling Cards");
		Debug.Log ("Pre-shuffle first card is "+listOfAvailableDates[0]+
		           ". Pre-shuffle last card is "+ listOfAvailableDates[listOfAvailableDates.Count-1]);

		//for each item in the years array ...
		for (int i = 0; i < listOfAvailableDates.Count; i++ )
		{
			//save the current slotted item into temp
			int temp = listOfAvailableDates[i];
			//pick a random slot between the current slot and the end of the list
			int r = Random.Range(i, listOfAvailableDates.Count);
			//save what is in the randomly slots slot in the current slot
			listOfAvailableDates[i] = listOfAvailableDates[r];
			//save what was in the current slot in the randomly chosen slot
			listOfAvailableDates[r] = temp;
		}
		//send that back to the program
		Debug.Log ("Post-shuffle first card is "+listOfAvailableDates[0]+
		           ". Post-shuffle last card is "+ listOfAvailableDates[listOfAvailableDates.Count-1]);
		return listOfAvailableDates;
	}

	//STEP 3!
	void SetupHand(){
		Debug.Log("SetupHand start - number of available cards = "+ listOfAvailableDates.Count);
		for (int i = 0; i < 5; i++ )
		{
			//grab the first five dates from the list of available dates and save into 
			handOfCards.Add(listOfAvailableDates[0]);
			//save what was in the current slot in the randomly chosen slot
			//			years[r] = temp;
			listOfAvailableDates.RemoveAt(0);
			Debug.Log(handOfCards[i]+"added to Hand list and removed from available dates");
		}
		Debug.Log("SetupHand end - number of available cards = "+ listOfAvailableDates.Count);
	}
	
	//STEP 4!
	void DealCard(){
		//for each date in handOfCards List ...
		for (int i = 0; i < 5; i++) {
			//instantiate a card ... move it 10 x over with each generated card ...
			Card card = (Card)Instantiate (CardTemplate, new Vector3 (i * -10, 0), Quaternion.identity);
			//send the currently selected card to the setupcard function in Card.cs
			card.SetupCard (handOfCards [i]);
			Debug.Log("Dealing " + handOfCards[i]+ " to the Hand.");
			//handOfCards;
		}
	}

	//STEP 5!
	void CardtoTimeline() {
		for (int i = 0; i < 4; i++) {
			GameObject temp = GameObject.Find("TL_Space_"+i);

			Card foo = temp.GetComponent<Card>();

			foo.SetupCard (cardsOnTimeline [i+firstTimelineCard]);
			foo.ShowDate();
			Debug.Log("Placing " + cardsOnTimeline[i]+ " to the Timeline.");
		}
	}
	
	//ZOOM in on a card!
	public void CardZoom(int year) {
		// display a second version of the card, larger and in the center of the hand.
		Debug.Log("CardZoom start ...");
			selectedCard =  GameObject.Find("CardZoomTemplate(Clone)");

		if(!selectedCard) {
				Card zoom = (Card)Instantiate (CardZoomTemplate, new Vector3 (-20, 1,-10), Quaternion.identity);
				zoom.SetupCard (year);
			} else {
				Card zoom = selectedCard.GetComponent<Card>();
				zoom.SetupCard(year);
			}

	}

	public void ScrollTimeline(int x) {
		Debug.Log("X = "+x);
		if(cardsOnTimeline.Count > 4) {
			if(x == 1) {
				firstTimelineCard++;
				if(firstTimelineCard > cardsOnTimeline.Count-4) {
					firstTimelineCard = cardsOnTimeline.Count-4;
				}
				Debug.Log("Going Right");
			} else if(x == -1) {
				firstTimelineCard--;
				if(firstTimelineCard < 0) {
					firstTimelineCard = 0;
				}
				Debug.Log("Going Left");
			} 
			Debug.Log(firstTimelineCard);
			CardtoTimeline();
		}
	}

//
//	public void AddtoTimeline(){
//		cardsOnTimeline.Add();
//		handOfCards.RemoveAt(r);
//	}

	public void SortTimeline() {
		cardsOnTimeline.Sort();
	}

	// Update is called once per frame
		void Update () {
	}

	void Reset() {
		listOfAvailableDates = yearlist;
	
	}	}