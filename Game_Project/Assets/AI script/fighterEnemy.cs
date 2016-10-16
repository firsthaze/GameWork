using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class fighterEnemy : MonoBehaviour {
    GameObject controller;
    GameObject eventSystem;
	GameObject musicControll;
	Renderer allowAtk;
	List<GameObject> target,canATK,goATK;
	int countLine,minLine,minHP,n;
    bool isActive;
	bool isAllow;
	int masterHP;
	// Use this for initialization
	void Start () {
		musicControll = GameObject.Find ("MusicController");
		isAllow = false;
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
			StartCoroutine(SpaceTime ());
			if(isAllow)
				starATK ();
		}
	}

	void starATK(){
		    isAllow = false;
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
			Debug.Log ("toATK is : " + toATK);
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
		    musicControll.GetComponent<musicController> ().ChoiceOneShot (8);
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
		Debug.Log ("fighter攻擊完了");
	}

	IEnumerator toWaite(){
		yield return new WaitForSeconds (1);
		allowAtk.material.color = Color.gray;
	}

	IEnumerator SpaceTime(){
		yield return new WaitForSeconds (2f);
		isAllow = true;
	}
}
