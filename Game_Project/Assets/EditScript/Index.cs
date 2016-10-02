using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SocketIO;
using System;
using System.Linq;

public class Index : MonoBehaviour {
	Transform sceneFade;
	GameObject socket;
	SocketIOComponent user;
	JSONObject userID;
	private string token;

	// Use this for initialization
	void Start () {
		socket = GameObject.FindGameObjectWithTag ("Socket");
		user = socket.GetComponent<SocketIOComponent> ();
		token = SystemInfo.deviceUniqueIdentifier;
		userID = new JSONObject ();
		userID.AddField ("token", token);
		foreach (GameObject allCard in GameObject.FindGameObjectsWithTag("card")) {
			allCard.GetComponent<BoxCollider2D> ().enabled = false;
			sceneFade = allCard.transform.GetChild (10);
			sceneFade.transform.gameObject.SetActive (true);
		}
		user.Emit ("GetIndex", userID);
	}
	
	// Update is called once per frame
	void Update () {
		user.On ("passIndex",getIndex);
	}

	public void getIndex(SocketIOEvent e)
	{
       isOwnCard ( e.data["indexArray"].list.ToArray());
	}

	void isOwnCard(JSONObject[] cardArray){
		foreach (JSONObject card in cardArray) {
			int toIndex = (int)card.f;
			Debug.Log ("get cardIndex is :" + toIndex);
			foreach (GameObject allCard in GameObject.FindGameObjectsWithTag("card")) {
				Debug.Log ("cardNum is :" + allCard.GetComponent<card_attribute> ().cardNum);
				if (allCard.GetComponent<card_attribute> ().cardNum == toIndex) {
					Debug.Log ("cardNum isequal to index");
					sceneFade = allCard.transform.GetChild (10);
					sceneFade.transform.gameObject.SetActive (false);
					allCard.GetComponent<BoxCollider2D> ().enabled = true;
				}
			}
		}
	}
}
