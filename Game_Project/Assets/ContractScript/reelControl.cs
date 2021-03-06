﻿using UnityEngine;
using System.Collections;
using SocketIO;

public class reelControl : MonoBehaviour {
	public GameObject showCard;
	public GameObject eventSystem;
	public GameObject fade;
	public GameObject openReel;
	public GameObject[] reels;
	public GameObject messageBoard;
	public float speed;
	public GameObject particalSystem;
	private bool isShowCard;
	private BoxCollider2D reelCollider;
	private string token;
	private int setCardNumber;
	JSONObject userID;
	GameObject socket;
	SocketIOComponent user;
	GameObject musicControll;

	// Use this for initialization
	void Start () {
		musicControll = GameObject.Find ("MusicController");
		musicControll.GetComponent<musicController> ().PlayBackGroundMusic (15);
		socket = GameObject.FindGameObjectWithTag ("Socket");
		user = socket.GetComponent<SocketIOComponent> ();
		token = SystemInfo.deviceUniqueIdentifier;
		userID = new JSONObject ();
		userID.AddField ("token", token);
		isShowCard = false;
		eventSystem = GameObject.FindGameObjectWithTag ("eventsystem");
	}
	
	// Update is called once per frame
	void Update () {
		user.On("returnCardNumber", getCardNumber);
		if (isShowCard) {
			if (showCard.transform.position.y  > 200) {
				showCard.transform.position = new Vector3 (showCard.transform.position.x, showCard.transform.position.y - speed * Time.deltaTime, showCard.transform.position.z);
			}else {
				showCard.transform.position = new Vector3 (showCard.transform.position.x, 200f, showCard.transform.position.z);
				isShowCard = false;
				showCard.GetComponent<BoxCollider2D> ().enabled = true;
				particalSystem.SetActive (false);
			}
		} 
	}

	public void GoToServer(){
		Debug.Log ("onCLick");
		if (eventSystem.GetComponent<checkStoneNumber> ().stone >= 25) {
			musicControll.GetComponent<musicController> ().ChoiceOneShot (14);
			Debug.Log ("in go Contract");
			eventSystem.GetComponent<checkStoneNumber> ().checkMyStone ();
			goContract ();
		}
		else{
			Debug.Log ("show board");
			musicControll.GetComponent<musicController> ().ChoiceOneShot (4);
			messageBoard.SetActive (true);
			openReel.SetActive (false);
		}
	}

	public void ChangeAnother(){
		musicControll.GetComponent<musicController> ().ChoiceOneShot (4);
		foreach (GameObject reel in reels) {
			reel.SetActive (true);
			reelCollider = reel.GetComponent<BoxCollider2D> ();
			reelCollider.enabled = true;
		}
		fade.SetActive (false);
		openReel.SetActive (false);
	}

	void goContract(){
		user.Emit ("Contract", userID);
	}
	IEnumerator spaceTime(){
		yield return new WaitForSeconds (2);
	}
	public void getCardNumber(SocketIOEvent e)
	{
		setCardNum ( e.data["cardNum"].f);
		openReel.SetActive (false);
		particalSystem.SetActive (true);
		isShowCard = true;
	}

	void setCardNum(float cardNumber){
		setCardNumber = (int)cardNumber;
		Debug.Log ("setCardNumber is :" + setCardNumber);
	}

	public void MessageBoardOnclick(){
		musicControll.GetComponent<musicController> ().ChoiceOneShot (4);
		ChangeAnother ();
		messageBoard.SetActive (false);
	}

	public int getCardNum(){
		return setCardNumber;
	} 
}
