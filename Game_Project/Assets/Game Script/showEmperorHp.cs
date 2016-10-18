using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showEmperorHp : MonoBehaviour {
	public Text enemyHp;
	GameObject musicControll;
	int playMusic;
	int getHp;
	GameObject eventSystem;
	// Use this for initialization
	void Start () {
		playMusic = 1;
		musicControll = GameObject.Find("MusicController");
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
			if (playMusic == 1) {
				musicControll.GetComponent<musicController> ().ChoiceOneShot (10);
				StartCoroutine (musicControll.GetComponent<musicController> ().TurnOffMusic ());
				playMusic--;
			}
			StartCoroutine(eventSystem.GetComponent<victory> ().victoryBoard ());
		}
	}
}
