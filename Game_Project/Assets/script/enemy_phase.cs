using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class enemy_phase : MonoBehaviour {
	List<GameObject> Monsters;
	GameObject[] findMonster;
	GameObject buttonEndPhase;
	public int countMonsters,isfinish;
	// Use this for initialization
	void Start () {
		countMonsters = 0;
		isfinish = 0;
		buttonEndPhase = GameObject.Find ("finish_phase");
		Monsters = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		checkfinish ();
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

	void checkfinish(){
		if (isfinish == countMonsters && countMonsters != 0) {
			isfinish = 0;
			countMonsters = 0;
			this.GetComponent<end_phase> ().ismyturn = true;
			buttonEndPhase.GetComponent<Button> ().interactable = true;
		}
	}
}
