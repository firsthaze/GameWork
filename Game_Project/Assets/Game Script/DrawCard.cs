using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SocketIO;
using Newtonsoft.Json;

public class DrawCard : MonoBehaviour {
	public GameObject[] cardsObject;

	// Use this for initialization
	void Start () {
		setcardnum ();
	}

	void setcardnum(){
		int i = 0;
		foreach (GameObject card in cardsObject) {
			card.GetComponent<card_attribute> ().cardNum = i;
			i++;
		}
	}

	// Update is called once per frame
	void Update () {
	}
}
