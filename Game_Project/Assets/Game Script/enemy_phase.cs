using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class enemy_phase : MonoBehaviour {
	public GameObject TurnChange;
	GameObject musicControll;
	List<GameObject> Monsters;
	GameObject[] findMonster;
	GameObject buttonEndPhase;
	GameObject eventSystem;
	GameObject territoryButton;
	public int countMonsters,isfinish;
	Renderer finishActive;
	// Use this for initialization
	void Start () {
		musicControll = GameObject.Find ("MusicController");
		countMonsters = 0;
		isfinish = 1;
		buttonEndPhase = GameObject.Find ("finish_phase");
		territoryButton = GameObject.Find ("territory_button");
		eventSystem = GameObject.FindGameObjectWithTag ("eventsystem");
		Monsters = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(checkfinish ());
	}

	public void checkMyTurn(){
		    Monsters.Clear ();
			findMonster = GameObject.FindGameObjectsWithTag ("enemyMonster");
			foreach (GameObject toMove in findMonster) {
				Monsters.Add (toMove);
				countMonsters++;
			}
			foreach (GameObject toMove in Monsters) {
				toMove.GetComponent<enemyAttribute> ().isActive = true;
			}

	}

	IEnumerator checkfinish(){
		if (isfinish == countMonsters && countMonsters != 0) {
			Debug.Log("進到finish");
			isfinish = 1;
			countMonsters = 0;
			yield return new WaitForSeconds (2.5f);
			musicControll.GetComponent<musicController> ().ChoiceOneShot (9);
			StartCoroutine(ShowTurnChange ());
			eventSystem.GetComponent<messageController> ().receiveMessage(1);
			this.GetComponent<end_phase> ().ismyturn = true;
			buttonEndPhase.GetComponent<Button> ().interactable = true;
			territoryButton.GetComponent<Button> ().interactable = true;
			foreach (GameObject tolive in GameObject.FindGameObjectsWithTag ("ourMonster")) {
				finishActive = tolive.GetComponent<Renderer> ();
				finishActive.material.color = Color.white;
				tolive.GetComponent<recordWhichCard> ().atkChance = 1;
			}
			eventSystem.GetComponent<controllHand> ().expansion ();
		}
	}

	IEnumerator ShowTurnChange(){
		Debug.Log ("InShowTurnChange");
		TurnChange.SetActive (true);
		yield return new WaitForSeconds (1.5f);
		TurnChange.SetActive (false);
		Debug.Log ("InShowTurnChangeFinish");
	}

	IEnumerator SpaceTime(){
		Debug.Log ("InspaceTime");
		yield return new WaitForSeconds (1.5f);
		Debug.Log ("InspaceTimefinish");
	}
}
