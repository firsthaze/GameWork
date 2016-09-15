using UnityEngine;
using System.Collections;

public class tower_create : MonoBehaviour {
	private float time_f;
	// Use this for initialization
	void Start () {
		time_f = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		Shake ();
	}

	void Shake(){

		if (time_f > 0) {
				time_f -= Time.deltaTime;
				this.transform.Translate (0, 0.015f, 0);	
		}
		
	}
}
