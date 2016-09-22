using UnityEngine;
using System.Collections;

public class reelControl : MonoBehaviour {
	public GameObject fade;
	public GameObject openReel;
	public GameObject[] reels;
	private BoxCollider2D reelCollider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToServer(){
		
	}

	public void ChangeAnother(){
		foreach (GameObject reel in reels) {
			reel.SetActive (true);
			reelCollider = reel.GetComponent<BoxCollider2D> ();
			reelCollider.enabled = true;
		}
		fade.SetActive (false);
		openReel.SetActive (false);
	}
}
