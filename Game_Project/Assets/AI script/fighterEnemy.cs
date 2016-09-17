using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class fighterEnemy : MonoBehaviour {
    GameObject controller;
    GameObject eventSystem;
	Renderer allowAtk;
	List<GameObject> target,canATK,goATK;
	int countLine,minLine,minHP,n;
    bool isActive;
	int masterHP;
	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("controller");
		eventSystem = GameObject.FindGameObjectWithTag ("eventsystem");
		minLine = 50;
		minHP = 100;
		target = new List<GameObject> ();
		canATK = new List<GameObject> ();
		goATK = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		isActive = GetComponent<enemyAttribute>().isActive;
		if (isActive) {
			starATK ();
		}
	}

	void starATK(){
			
			target.Clear ();
			canATK.Clear ();
			goATK.Clear ();

			foreach (GameObject toList in GameObject.FindGameObjectsWithTag ("ourMonster")) {
				target.Add (toList);
			}

			foreach (GameObject atkTarget in target) {
				countLine = (int)(this.transform.position.z - atkTarget.GetComponent<Transform> ().position.z);
				if (minLine > countLine) {
					minLine = countLine;
				}
			}

			foreach(GameObject atkTarget in target){
				countLine = (int)(this.transform.position.z - atkTarget.GetComponent<Transform> ().position.z);
				if (minLine == countLine) {
					canATK.Add (atkTarget);
				}
			}

		    foreach (GameObject toATK in canATK) {
			    if (minHP >= toATK.GetComponent<recordWhichCard> ().HP) {
				minHP = toATK.GetComponent<recordWhichCard> ().HP;
			    }
		    }

			foreach (GameObject toATK in canATK) {
				if (minHP == toATK.GetComponent<recordWhichCard> ().HP) {
					minHP = toATK.GetComponent<recordWhichCard> ().HP;
					goATK.Add (toATK);
				}
			}
			if (goATK.Count != 0) {
			    allowAtk = goATK [0].GetComponent<Renderer> ();
			    allowAtk.material.color = Color.red;
				goATK [0].GetComponent<recordWhichCard> ().HP = goATK [0].GetComponent<recordWhichCard> ().HP - this.GetComponent<enemyAttribute> ().ATK;
			    StartCoroutine (toWaite ());
				this.GetComponent<enemyAttribute> ().ATK++;
				controller.GetComponent<enemy_phase> ().isfinish++;
			    GetComponent<enemyAttribute> ().isActive = false;
			    minLine = 50;
			    minHP = 100;
			    
			}
			else {
			    Debug.Log(this.transform.name + "has already attacked");
			    showmasterHP.masterHP = showmasterHP.masterHP - this.GetComponent<enemyAttribute> ().ATK;
			    eventSystem.GetComponent<messageController> ().receiveMessage (6);
				this.GetComponent<enemyAttribute> ().ATK++;
				controller.GetComponent<enemy_phase> ().isfinish++;
			    GetComponent<enemyAttribute> ().isActive = false;
			    minLine = 50;
			    minHP = 100;
			}
		Debug.Log ("Archer攻擊完了");
	}

	IEnumerator toWaite(){
		yield return new WaitForSeconds (1);
		allowAtk.material.color = Color.white;
	}	
}
