using UnityEngine;
using System.Collections;

public class chooseReel : MonoBehaviour {
	public GameObject openReel;
	public GameObject fade;
	public GameObject[] reels;
	private BoxCollider2D reelCollider;
	GameObject musicControll;
	// Use this for initialization
	void Start () {
		musicControll = GameObject.Find ("MusicController");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		musicControll.GetComponent<musicController> ().ChoiceOneShot (4);
		foreach (GameObject reel in reels) {
			reelCollider = reel.GetComponent<BoxCollider2D> ();
			reelCollider.enabled = false;
		}
		openReel.SetActive (true);
		fade.SetActive (true);
		this.gameObject.SetActive(false);
	}
}
