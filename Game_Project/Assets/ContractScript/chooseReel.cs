using UnityEngine;
using System.Collections;

public class chooseReel : MonoBehaviour {
	public GameObject openReel;
	public GameObject fade;
	public GameObject[] reels;
	private BoxCollider2D reelCollider;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		foreach (GameObject reel in reels) {
			reelCollider = reel.GetComponent<BoxCollider2D> ();
			reelCollider.enabled = false;
		}
		openReel.SetActive (true);
		fade.SetActive (true);
		this.gameObject.SetActive(false);
	}
}
