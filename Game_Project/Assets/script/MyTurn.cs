using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(DrawCard))]
public class MyTurn : MonoBehaviour {
	public List<int> cardIdList;
	public GameObject controller;
	public GameObject cardParent_refrence;
	GameObject cardPrefab;
	GameObject eventSystem;

	Transform parent;
	DrawCard drawCard;

	public void GetCards(){
		foreach (int i in cardIdList) {
			foreach (GameObject j in drawCard.Cards) {
				if (i == j.GetComponent<card_attribute> ().cardNum) {
					if (cardParent_refrence.transform.parent.childCount <= 6) {
						cardPrefab = j;
						GameObject cardCopy = (GameObject)Instantiate (cardPrefab);
						cardCopy.transform.SetParent (parent);
						cardCopy.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1f, 1f);
						cardCopy.transform.SetSiblingIndex (this.transform.GetSiblingIndex ());
						break;
					} else {
						Debug.Log ("手牌已滿");
						break;
					}

				} 
			}
			cardIdList.Remove(i);

			break;
		}

	}

	// Use this for initialization
	void Start () {
		eventSystem = GameObject.FindGameObjectWithTag ("eventsystem");
		drawCard = GetComponent<DrawCard> ();
		Shuffle ();
		parent = cardParent_refrence.transform.parent;
	}


	// Update is called once per frame
	void Update () {
	}

	public void checkMyTurn(){
		    todrawcard();
			this.GetComponent<dice>().throwdice ();
	}
		
	void todrawcard(){
		if (cardIdList.Count == 0) {
			Debug.Log ("沒手牌了");
		} else {
			GetCards ();
		}
	}

	public void Shuffle(){
		if (cardIdList == null) {
		     
			cardIdList = new List<int> ();
		} else {
			cardIdList.Clear ();
		}

		for (int i = 0; i <= 3; i++) {
			cardIdList.Add (i);
		}

		int n = cardIdList.Count;

		while (n > 1) {
			n--;
			int k = Random.Range (0, n + 1);
			int temp = cardIdList [k];
			cardIdList [k] = cardIdList [n];
			cardIdList [n] = temp;
		}

	}


}
