using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class end_phase : MonoBehaviour {
	public bool ismyturn;
	GameObject eventSystem;
	GameObject buttonEndPhase;
	GameObject territoryButton;
	Renderer finishActive;
	// Use this for initialization
	void Start () {
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
		OnClickToDo ();
    }

	public void OnClickToDo(){
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
}