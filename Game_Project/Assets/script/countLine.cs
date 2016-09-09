using UnityEngine;
using System.Collections;

public class countLine : MonoBehaviour {
	public int monsterDistance;
	public bool isATK;
	private int ourMonsterZ,enemyMonsterZ;
	// Use this for initialization
	void Start () {
		isATK = false;
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
					}
				}
				else if (isATK) {
					if (hit.transform.tag == "enemyMonster") {
						enemyMonsterZ=cor_process (hit.transform.position.z);
						isATK = false;
						monsterDistance = ourMonsterZ + enemyMonsterZ;
						Debug.Log ("兩著的距離 : " + monsterDistance);
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
