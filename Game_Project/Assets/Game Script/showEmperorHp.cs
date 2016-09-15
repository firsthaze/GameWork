using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showEmperorHp : MonoBehaviour {
	public Text enemyHp;
	int getHp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		getHp = GetComponent<enemyAttribute> ().HP;
		enemyHp.text = "" + getHp;
	}

}
