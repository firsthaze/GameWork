using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawCard : MonoBehaviour {
	public GameObject kaku;
	public GameObject johnson;
	public GameObject shashow;

	public List<GameObject> Cards;


	// Use this for initialization
	void Start () {
		Cards = new List<GameObject> ();
		Cards.Add (kaku);
		Cards.Add (johnson);
		Cards.Add (shashow);
		Debug.Log ("finish cards");
		setcardnum ();
	}

	void setcardnum(){
		kaku.GetComponent<card_attribute> ().cardNum = 0;
		johnson.GetComponent<card_attribute> ().cardNum = 1;
		shashow.GetComponent<card_attribute> ().cardNum = 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
