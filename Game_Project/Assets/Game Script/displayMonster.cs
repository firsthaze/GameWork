using UnityEngine;
using System.Collections;

public class displayMonster : MonoBehaviour {
	public GameObject eventsystem;
	DrawCard drawcard;
	gameStart gamestart;
	GameObject cardPrefab;
	GameObject cardCopy;
	GameObject carddisplayzone;
	Transform parent;

	// Use this for initialization
	void Start () {
		gamestart = eventsystem.GetComponent<gameStart> ();
		drawcard = eventsystem.GetComponent<DrawCard> ();
		carddisplayzone = GameObject.FindGameObjectWithTag("displaycardrefrence");
		parent = carddisplayzone.transform.parent;
	}

	// Update is called once per frame
	void Update () {
		clickMonster ();
	}

	void clickMonster(){

		if (Input.GetMouseButtonDown (0)) {

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.tag == "ourMonster" || hit.transform.tag == "eMonster") {
					if (cardCopy != null) {
						Destroy (cardCopy);
						foreach (GameObject card in gamestart.cardsObject) {
							if (hit.transform.GetComponent<recordWhichCard> ().cardNum == card.GetComponent<card_attribute> ().cardNum) {
								cardPrefab = card;
								cardCopy = (GameObject)Instantiate (cardPrefab);
								cardCopy.transform.SetParent (parent);
								cardCopy.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1f, 1f);
								cardCopy.GetComponent<card_attribute> ().ATK = hit.transform.GetComponent<recordWhichCard> ().ATK;
								cardCopy.GetComponent<card_attribute> ().HP = hit.transform.GetComponent<recordWhichCard> ().HP;
							} else {

							}
						}
					} else {
						foreach (GameObject card in gamestart.cardsObject) {
							if (hit.transform.GetComponent<recordWhichCard> ().cardNum == card.GetComponent<card_attribute> ().cardNum) {
								cardPrefab = card;
								cardCopy = (GameObject)Instantiate (cardPrefab);
								cardCopy.transform.SetParent (parent);
								cardCopy.GetComponent<RectTransform> ().localScale = new Vector3 (1.6f, 1.6f, 1.6f);
								cardCopy.GetComponent<card_attribute> ().ATK = hit.transform.GetComponent<recordWhichCard> ().ATK;
								cardCopy.GetComponent<card_attribute> ().HP = hit.transform.GetComponent<recordWhichCard> ().HP;
							} else {

							}
						}

					}
				} else {
					if (cardCopy != null)
						Destroy (cardCopy);
				}
			}
		} 
		else if (Input.GetMouseButtonUp (0)) {
			if (cardCopy != null) 
				Destroy (cardCopy);
		}
	}
}
