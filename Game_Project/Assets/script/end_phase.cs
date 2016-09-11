using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class end_phase : MonoBehaviour {
	public bool ismyturn;
	GameObject eventSystem;
	GameObject buttonEndPhase;
	GameObject territoryButton;
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
		StartCoroutine (OnClickToDo ());
    }

	public IEnumerator OnClickToDo(){
		if (eventSystem.GetComponent<MyTurn> ().cardIdList.Count == 0) {
			eventSystem.GetComponent<messageController> ().receiveMessage (3);
			yield return new WaitForSeconds (2);
		} 
		eventSystem.GetComponent<messageController> ().receiveMessage (2);
		ismyturn = false;
		eventSystem.GetComponent<MyTurn> ().checkMyTurn ();
		GetComponent<enemy_phase> ().checkMyTurn ();
		buttonEndPhase.GetComponent<Button> ().interactable = false;
		territoryButton.GetComponent<Button> ().interactable = false;
	}
}