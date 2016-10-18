using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class end_phase : MonoBehaviour {
	public bool ismyturn;
	GameObject musicControll;
	public GameObject TurnChange;
	GameObject eventSystem;
	GameObject buttonEndPhase;
	GameObject territoryButton;
	Renderer finishActive;
	// Use this for initialization
	void Start () {
		musicControll = GameObject.Find ("MusicController");
		ismyturn = true;
		eventSystem = GameObject.FindGameObjectWithTag ("eventsystem");
		buttonEndPhase = GameObject.Find ("finish_phase");
		territoryButton = GameObject.Find ("territory_button");
		eventSystem.GetComponent<MyTurn> ().checkMyTurn ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnClick(){
		musicControll.GetComponent<musicController> ().ChoiceOneShot (9);
		OnClickToDo ();
    }

	public void OnClickToDo(){
		eventSystem.GetComponent<controllHand> ().shrink ();
		StartCoroutine(ShowTurnChange ());
		foreach (GameObject Monster in GameObject.FindGameObjectsWithTag ("ourMonster")){
			finishActive = Monster.GetComponent<Renderer> ();
			finishActive.material.color = Color.gray;
		}
		buttonEndPhase.GetComponent<Button> ().interactable = false;
		territoryButton.GetComponent<Button> ().interactable = false;
		eventSystem.GetComponent<messageController> ().receiveMessage (2);
		ismyturn = false;
		eventSystem.GetComponent<MyTurn> ().checkMyTurn ();
		GetComponent<enemy_phase> ().checkMyTurn ();
	}

	IEnumerator ShowTurnChange(){
		Debug.Log ("InShowTurnChange");
		TurnChange.SetActive (true);
		yield return new WaitForSeconds (1.5f);
		TurnChange.SetActive (false);
		Debug.Log ("InShowTurnChangeFinish");
	}
}