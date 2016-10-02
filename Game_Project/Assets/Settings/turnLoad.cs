using UnityEngine;
using System.Collections;

public class turnLoad : MonoBehaviour {
	public GameObject load;
	public float speed;
	Vector3 turnspeed;
	// Use this for initialization
	void Start () {
		turnspeed = new Vector3 (0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		load.transform.Rotate (turnspeed, -speed * Time.deltaTime);
	}
}
