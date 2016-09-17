using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class enemy_phase : MonoBehaviour {
	List<GameObject> Monsters;
	GameObject[] findMonster;
	GameObject buttonEndPhase;
	GameObject eventSystem;
	GameObject territoryButton;
	public int countMonsters,isfinish;
	// Use this for initialization
	void Start () {
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
			    Debug.Log ("enemyMonster is :" + toMove.transform.name);
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
			yield return new WaitForSeconds (2);
			eventSystem.GetComponent<messageController> ().receiveMessage(1);
			this.GetComponent<end_phase> ().ismyturn = true;
			buttonEndPhase.GetComponent<Button> ().interactable = true;
			territoryButton.GetComponent<Button> ().interactable = true;
			foreach (GameObject tolive in GameObject.FindGameObjectsWithTag ("ourMonster")) {
				tolive.GetComponent<recordWhichCard> ().atkChance = 1;
			}
		}
	}
}
