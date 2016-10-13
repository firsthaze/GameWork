using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class countLine : MonoBehaviour {
	GameObject eventSystem,tmp;
	public static int mode;    //管理點擊觸發
	/*
	 * mode 0: 點擊空白處
	 *mode 1 : 已經點擊我方怪獸 
	 */
	public int monsterDistance,minLine,minHP,atkChance;
	public bool isATK;
	private int ourMonsterZ,enemyMonsterZ,ourMonsterAtk,enemyMonsterHp;
	List<GameObject> target,canATK;
	Renderer allowAtk;
	Transform showTarget;
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
					mode = 1;
					foreach (GameObject monster in GameObject.FindGameObjectsWithTag("ourMonster")) {
						showTarget = monster.transform.GetChild (0);
						showTarget.transform.gameObject.SetActive (false);
					}
					tmp = hit.transform.gameObject;
					showTarget = tmp.transform.GetChild (0);
					showTarget.transform.gameObject.SetActive (true);
					if (tmp.GetComponent<recordWhichCard> ().atkChance == 0) {
						eventSystem.GetComponent<messageController> ().receiveMessage (7);
					} else if (!isATK) {
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
				} else if (hit.transform.tag == "choosen") {
					if (isATK) {
						minLine = 50;
						enemyMonsterZ = cor_process (hit.transform.position.z);
						hit.transform.GetComponent<enemyAttribute> ().HP = hit.transform.GetComponent<enemyAttribute> ().HP - ourMonsterAtk;

						foreach (GameObject toAtk in canATK) {
							allowAtk = toAtk.GetComponent<Renderer> ();
							allowAtk.material.color = Color.white;
							toAtk.transform.tag = "enemyMonster";
						}
						isATK = false;
						monsterDistance = enemyMonsterZ - ourMonsterZ;
						tmp.GetComponent<recordWhichCard> ().atkChance--;
						allowAtk = tmp.GetComponent<Renderer> ();
						allowAtk.material.color = Color.gray;
					}
				} else {
					foreach (GameObject toAtk in canATK) {
						mode = 0;
						allowAtk = toAtk.GetComponent<Renderer> ();
						allowAtk.material.color = Color.white;
						toAtk.transform.tag = "enemyMonster";
						showTarget.transform.gameObject.SetActive (false);
					}
					isATK = false;
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
