using UnityEngine;
using System.Collections;

public class bigSize : MonoBehaviour {
	public GameObject bigText;
	public float speed;
	int time_i = 0;
	int loopTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (time_i <= 60) {
			time_i++;
			bigText.transform.localScale = new Vector3 (bigText.transform.localScale.x + speed * time_i, bigText.transform.localScale.y + speed * time_i, 0f);
		} else {
			time_i = 0;
			bigText.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		}
	}
}
