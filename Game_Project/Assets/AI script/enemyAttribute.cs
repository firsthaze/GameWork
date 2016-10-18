using UnityEngine;
using System.Collections;

public class enemyAttribute : MonoBehaviour {
	public int HP, ATK,cost;
	public bool isActive;
	GameObject musicControll;
	// Use this for initialization
	void Start () {
		musicControll = GameObject.Find ("MusicController");
		isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		checkHP ();
	}
	void checkHP(){
		if (HP <= 0) {
			if (this.gameObject.transform.name == "Emperor")
				HP = 0;
			else {
				musicControll.GetComponent<musicController> ().ChoiceOneShot (13);
				Destroy (this.gameObject);
			}
		}
	}
}
