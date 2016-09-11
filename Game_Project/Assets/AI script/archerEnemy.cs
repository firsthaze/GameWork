using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class archerEnemy : MonoBehaviour {
	GameObject controller;
	GameObject eventSystem;
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
				Debug.Log ("找到了可以攻擊目標:" + atkTarget.transform.name);
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
				Debug.Log ("攻擊目標 :" + toATK.transform.name);
			}
		}
		if (goATK.Count != 0) {
			goATK [0].GetComponent<recordWhichCard> ().HP = goATK [0].GetComponent<recordWhichCard> ().HP - this.GetComponent<enemyAttribute> ().ATK;
			controller.GetComponent<enemy_phase> ().isfinish++;
			GetComponent<enemyAttribute> ().isActive = false;
			minLine = 50;
			minHP = 100;
		}
		else {
			Debug.Log(this.transform.name + "has already attacked");
			showmasterHP.masterHP = showmasterHP.masterHP - this.GetComponent<enemyAttribute> ().ATK;
			eventSystem.GetComponent<messageController> ().receiveMessage (6);
			controller.GetComponent<enemy_phase> ().isfinish++;
			GetComponent<enemyAttribute> ().isActive = false;
			minLine = 50;
			minHP = 100;
		}
	}
}
