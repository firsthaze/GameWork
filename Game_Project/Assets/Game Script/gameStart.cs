using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class gameStart : MonoBehaviour {
	public Vector3 newScale = new Vector3 (1.0f, 1.0f, 1.0f);
	public GameObject[] cardsObject;
	public GameObject cardParent_refrence;
	GameObject eventSystem;
	GameObject cardPrefab;
	Transform parent;
	Transform sceneFade;
	// Use this for initialization
	void Start () {
		parent = cardParent_refrence.transform.parent;
		setcardnum ();
		if (ClickFinish.cardIndex == null) {
			ClickFinish.cardIndex = new List<int> ();
			ClickFinish.cardIndex.Add (0);
			ClickFinish.cardIndex.Add (1);
			ClickFinish.cardIndex.Add (2);
		}
		ShowHand ();
	}

	void setcardnum(){
		int i = 0;
		foreach (GameObject card in cardsObject) {
			card.GetComponent<card_attribute> ().cardNum = i;
			sceneFade = card.transform.GetChild (10);
			sceneFade.transform.gameObject.SetActive (false);
			i++;
		}
	}

	void ShowHand(){
		foreach (int cardNumber in ClickFinish.cardIndex) {
			foreach (GameObject card in cardsObject) {
				if (card.GetComponent<card_attribute> ().cardNum == cardNumber) {
					cardPrefab = (GameObject)Instantiate (card);
					cardPrefab.transform.SetParent (parent);
					cardPrefab.AddComponent<LayoutElement> ();
					cardPrefab.GetComponent<Transform> ().localScale = newScale;
					cardPrefab.GetComponent<LayoutElement> ().preferredWidth = 125;
					cardPrefab.GetComponent<LayoutElement> ().preferredHeight = 200;
					cardPrefab.GetComponent<LayoutElement> ().flexibleHeight = 0;
					cardPrefab.GetComponent<LayoutElement> ().flexibleWidth = 0;
					cardPrefab.AddComponent<CanvasGroup> ();
					cardPrefab.GetComponent<CanvasGroup> ().alpha = 1;
					cardPrefab.GetComponent<CanvasGroup> ().interactable = true;
					cardPrefab.GetComponent<CanvasGroup> ().blocksRaycasts = true;
					cardPrefab.AddComponent<DisplayCard> ();
					cardPrefab.GetComponent<DragCard> ().enabled = true;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
