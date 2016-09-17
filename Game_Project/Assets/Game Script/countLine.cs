using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class countLine : MonoBehaviour {
	GameObject eventSystem,tmp;
	public int monsterDistance,minLine,minHP,atkChance;
	public bool isATK;
	private int ourMonsterZ,enemyMonsterZ,ourMonsterAtk,enemyMonsterHp;
	List<GameObject> target,canATK;
	Renderer allowAtk;
	// Use this for initialization
	void Start () {
		eventSystem = GameObject.FindGameObjectWithTag ("eventsystem");
		isATK = false;
		minLine = 50;
		minHP = 100;
		target = new List<GameObject>();
		canATK = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		clickMonster ();
	}

	void clickMonster(){
		if (Input.GetMouseButton(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.tag == "ourMonster") {
					tmp = hit.transform.gameObject;
					if (tmp.GetComponent<recordWhichCard> ().atkChance == 0) {
						eventSystem.GetComponent<messageController> ().receiveMessage (7);
					}
					else if (!isATK){
						target.Clear ();
					    canATK.Clear ();
					    isATK = true;
				  	    ourMonsterZ = cor_process (hit.transform.position.z);
					    ourMonsterAtk = hit.transform.GetComponent<recordWhichCard> ().ATK;

					//找尋全部敵人跟判斷最近的線位
					foreach (GameObject enemyMonster in GameObject.FindGameObjectsWithTag ("enemyMonster")) {
						target.Add (enemyMonster);
						monsterDistance = (int)(enemyMonster.transform.position.z - this.transform.position.z);
						if (minLine > monsterDistance) {
							minLine = monsterDistance;
						    }
					    }

					//找尋可攻擊敵人
					foreach (GameObject atkTarget in target) {
						monsterDistance = (int)(atkTarget.transform.position.z - this.transform.position.z);
						if (minLine == monsterDistance) {
							canATK.Add (atkTarget);
						}
					}

					//可攻擊的敵人要變色
					foreach (GameObject toAtk in canATK) {
						allowAtk = toAtk.GetComponent<Renderer> ();
						allowAtk.material.color = Color.red;
						toAtk.transform.tag = "choosen";
					    }
				    }
				}

				else if (hit.transform.tag == "choosen") {
					 if (isATK) {
						minLine = 50;
						enemyMonsterZ=cor_process (hit.transform.position.z);
						hit.transform.GetComponent<enemyAttribute> ().HP =  hit.transform.GetComponent<enemyAttribute> ().HP - ourMonsterAtk;

						foreach (GameObject toAtk in canATK) {
							allowAtk = toAtk.GetComponent<Renderer> ();
							allowAtk.material.color = Color.white;
							toAtk.transform.tag = "enemyMonster";
						}
						isATK = false;
						monsterDistance = enemyMonsterZ-ourMonsterZ;
						tmp.GetComponent<recordWhichCard> ().atkChance--;
					}

				}

			}
		}
	}

	int cor_process(float coordinate){
		if (coordinate > 0)
			return (int)coordinate + 1;
		else
			return (int)coordinate;
	}
}
