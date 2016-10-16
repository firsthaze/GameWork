using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class archerEnemy : MonoBehaviour {
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

		//找尋全部我方單位
		foreach (GameObject toList in GameObject.FindGameObjectsWithTag ("ourMonster")) {
			target.Add (toList);
		}

		//判斷最小的線位
		foreach (GameObject atkTarget in target) {
			countLine = (int)(this.transform.position.z - atkTarget.GetComponent<Transform> ().position.z);
			if (minLine > countLine) {
				minLine = countLine;
			}
		}

		//找尋可攻擊單位
		foreach(GameObject atkTarget in target){
			countLine = (int)(this.transform.position.z - atkTarget.GetComponent<Transform> ().position.z);
			if ((minLine+1)>=countLine) {
				canATK.Add (atkTarget);
			}
		}

		//判斷血量最低單位
		foreach (GameObject toATK in canATK) {
			if (minHP >= toATK.GetComponent<recordWhichCard> ().HP) {
				minHP = toATK.GetComponent<recordWhichCard> ().HP;
			}
		}

		//尋找可攻擊的血量最低單位
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
			controller.GetComponent<enemy_phase> ().isfinish++;
			GetComponent<enemyAttribute> ().isActive = false;
			minLine = 50;
			minHP = 100;
		}
		else {
			showmasterHP.masterHP = showmasterHP.masterHP - this.GetComponent<enemyAttribute> ().ATK;
			eventSystem.GetComponent<messageController> ().receiveMessage (6);
			controller.GetComponent<enemy_phase> ().isfinish++;
			GetComponent<enemyAttribute> ().isActive = false;
			minLine = 50;
			minHP = 100;
		}

		Debug.Log ("Archer攻擊完了");
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
