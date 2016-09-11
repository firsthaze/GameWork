using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class countLine : MonoBehaviour {
	public int monsterDistance,minLine,minHP,n;
	public bool isATK;
	private int ourMonsterZ,enemyMonsterZ,ourMonsterAtk,enemyMonsterHp;
	List<GameObject> target,canATK;
	Renderer allowAtk;
	GameObject[] findMonster;
	// Use this for initialization
	void Start () {
		isATK = false;
		minLine = 50;
		minHP = 100;
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
				if(!isATK){
				if (hit.transform.tag == "ourMonster") {
					    isATK = true;
					    ourMonsterZ=cor_process (hit.transform.position.z);
						ourMonsterAtk = hit.transform.GetComponent<recordWhichCard>().ATK;

						findMonster = GameObject.FindGameObjectsWithTag ("enemyMonster");
						//找尋全部敵人跟判斷最近的線位
						foreach (GameObject enemyMonster in findMonster) {
							target.Add (enemyMonster);
							monsterDistance = (int)(enemyMonster.transform.position.z - this.transform.position.z);
							if (minLine > monsterDistance) {
								minLine = monsterDistance;
							}
						}

						//找尋可攻擊敵人
						foreach(GameObject atkTarget in target){
							monsterDistance = (int)(atkTarget.transform.position.z - this.transform.position.z);
							if (minLine == monsterDistance) {
								canATK.Add (atkTarget);
							}
						}

						//可攻擊的敵人要變色
						foreach(GameObject toAtk in canATK){
							allowAtk = toAtk.GetComponent<Renderer> ();
							allowAtk.material.color = Color.red;
							toAtk.transform.tag = "choosen";
						}
					}
				}
				else if (isATK) {
					if (hit.transform.tag == "choosen") {
						minLine = 50;
						enemyMonsterZ=cor_process (hit.transform.position.z);
						enemyMonsterHp =  hit.transform.GetComponent<enemyAttribute> ().HP;
						foreach (GameObject toAtk in canATK) {
							allowAtk = toAtk.GetComponent<Renderer> ();
							allowAtk.material.color = Color.white;
							toAtk.transform.tag = "enemyMonster";
						}
						isATK = false;
						monsterDistance = enemyMonsterZ-ourMonsterZ;
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
