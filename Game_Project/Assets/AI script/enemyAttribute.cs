using UnityEngine;
using System.Collections;

public class enemyAttribute : MonoBehaviour {
	public int HP, ATK,cost;
	public bool isActive;
	// Use this for initialization
	void Start () {
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
			else
				Destroy (this.gameObject);
		}
	}
}
