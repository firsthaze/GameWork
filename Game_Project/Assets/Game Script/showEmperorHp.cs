using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showEmperorHp : MonoBehaviour {
	public Text enemyHp;
	int getHp;
	GameObject eventSystem;
	// Use this for initialization
	void Start () {
		eventSystem = GameObject.FindGameObjectWithTag ("eventsystem");
		getHp = 30;
	}
	
	// Update is called once per frame
	void Update () {
		getHp = GetComponent<enemyAttribute> ().HP;
		enemyHp.text = "" + getHp;
		StartCoroutine(checkHP ());
	}

	public IEnumerator checkHP (){
		if (getHp <= 0) {
			//可能需要贏遊戲的動畫或音效
			yield return new WaitForSeconds (1);
			StartCoroutine(eventSystem.GetComponent<victory> ().victoryBoard ());
		}
	}
}
