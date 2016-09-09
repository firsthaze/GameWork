using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class fighterEnemy : MonoBehaviour {
	public GameObject controller;
    GameObject eventSystem;
	List<GameObject> target,canATK,goATK;
	int countLine,minLine,minHP,n;
    bool isActive;
	int masterHP;
	// Use this for initialization
	void Start () {

		eventSystem = GameObject.FindGameObjectWithTag ("eventsystem");
		masterHP = eventSystem.GetComponent<showmasterHP> ().masterHP;
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
			    Debug.Log ("找到了全部敵人:" + toList.transform.name);
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
				    Debug.Log ("找到了可以攻擊目標:" + atkTarget.transform.name);
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
				    Debug.Log ("攻擊目標 :" + toATK.transform.name);
				}
			}
			if (goATK.Count != 0) {
				goATK [0].GetComponent<recordWhichCard> ().HP = goATK [0].GetComponent<recordWhichCard> ().HP - this.GetComponent<enemyAttribute> ().ATK;
				this.GetComponent<enemyAttribute> ().ATK++;
				controller.GetComponent<enemy_phase> ().isfinish++;
			    GetComponent<enemyAttribute> ().isActive = false;
			    minLine = 50;
			    minHP = 100;
			}
			else {
				masterHP = masterHP - this.GetComponent<enemyAttribute> ().ATK;
				this.GetComponent<enemyAttribute> ().ATK++;
				controller.GetComponent<enemy_phase> ().isfinish++;
				eventSystem.GetComponent<showmasterHP> ().masterHP = masterHP;
			    GetComponent<enemyAttribute> ().isActive = false;
			    minLine = 50;
			    minHP = 100;
			}
	}
}
