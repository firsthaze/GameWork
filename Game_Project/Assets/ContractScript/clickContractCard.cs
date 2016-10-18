using UnityEngine;
using System.Collections;

public class clickContractCard : MonoBehaviour {
	GameObject musicControll;
	public GameObject[] card;
	public GameObject cardBack;
	public GameObject wholeCard;
	public GameObject fade;
	public GameObject positionToReturn;
	public GameObject particalSystem;
	GameObject eventSystem;
	private bool turn,turnRight;
	public float speed;
	private int mode;
	private int cardNum;
	Transform scenefade;
	// Use this for initialization
	void Start () {
		musicControll = GameObject.Find("MusicController");
		turn = false;
		turnRight = false;
		mode = 1;
		eventSystem = GameObject.FindGameObjectWithTag ("eventsystem");
	}
	
	// Update is called once per frame
	void Update () {
		if (turn) {
			if (cardBack.transform.localScale.x > 0)
				cardBack.transform.localScale = new Vector3 (cardBack.transform.localScale.x - speed * Time.deltaTime, 1.3f, 1.3f);
			else {
				cardBack.transform.localScale = new Vector3 (0f, 1.3f, 1.3f);
				card[cardNum].SetActive (true);
				cardBack.SetActive (false);
				turnRight = true;
				turn = false;
				scenefade = card [cardNum].transform.GetChild (10);
				scenefade.gameObject.SetActive (false);
			}
		}

		if (turnRight) {
			if (card[cardNum].transform.localScale.x < 1.3f) {
				card[cardNum].transform.localScale = new Vector3 (card[cardNum].transform.localScale.x + speed * Time.deltaTime, 1.3f, 1.3f);
			}
			else {
				card[cardNum].transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
				turnRight = false;
				mode = 2;
			}
		}
	}

	void OnMouseDown(){
		Debug.Log ("CLick the Card!");
		if (mode == 1) {
			musicControll.GetComponent<musicController> ().ChoiceOneShot (12);
			Debug.Log ("OnMouseDown mode 1");
			cardNum = eventSystem.GetComponent<reelControl> ().getCardNum();
			turn = true;
		}
		else {
			Debug.Log ("OnMouseDown mode 2");
			musicControll.GetComponent<musicController> ().ChoiceOneShot (4);
			mode =1;
			fade.SetActive (false);
			cardBack.SetActive (true);
			cardBack.transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);
			card[cardNum].transform.localScale = new Vector3(0f, 0f, 0f);
			card[cardNum].SetActive (false);
			wholeCard.GetComponent<BoxCollider2D> ().enabled = false;
			wholeCard.transform.position = positionToReturn.transform.position;
			eventSystem.GetComponent<reelControl> ().ChangeAnother ();
		}
	}
}
