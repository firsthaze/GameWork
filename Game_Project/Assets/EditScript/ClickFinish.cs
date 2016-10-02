using UnityEngine;
using System.Collections;
using SocketIO;
using System.Collections.Generic;
using Newtonsoft.Json;

[RequireComponent(typeof(Index))]
public class ClickFinish : MonoBehaviour {
	SocketIOComponent user;
	GameObject socket;
	JSONObject myHand;
	List<int> cardIndex;
	private string passCardIndex;
	private string token;

	// Use this for initialization
	void Start () {
		cardIndex = new List<int> ();
		myHand = new JSONObject();
		token = SystemInfo.deviceUniqueIdentifier;
		myHand.AddField ("token", token);
		socket = GameObject.FindGameObjectWithTag ("Socket");
		user = socket.GetComponent<SocketIOComponent> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnClick(){
		CollectCard ();
	}

	void CollectCard(){
		foreach (GameObject card in GameObject.FindGameObjectsWithTag("myHand")) {
			Debug.Log ("card is : " + card.GetComponent<card_attribute> ().cardNum);
			cardIndex.Add(card.GetComponent<card_attribute> ().cardNum);
		}
		passCardIndex = JsonConvert.SerializeObject (cardIndex);
		myHand.AddField ("myHand", passCardIndex);
		Debug.Log ("passCardIndex is : " + passCardIndex);
		user.Emit ("passMyHand", myHand);
	}
}
