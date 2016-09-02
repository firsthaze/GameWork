using UnityEngine;
using System.Collections;

public class monster_create : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Airborne ();
	}

	void Airborne(){
		if (this.transform.position.y>=0.81f) {
			this.transform.Translate (0, -0.15f, 0);	
		}

	}
}
