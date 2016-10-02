using UnityEngine;
using System.Collections;

public class checkLevel : MonoBehaviour {
	public GameObject next;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void openNextLevel(){
		next.SetActive (true);
	}
}
