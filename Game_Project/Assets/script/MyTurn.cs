using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(DrawCard))]
public class MyTurn : MonoBehaviour {
	List<int> cardIdList;
	public GameObject controller;
	public GameObject cardParent_refrence;
	GameObject cardPrefab;

	Transform parent;
	DrawCard drawCard;

	public void GetCards(){
		Debug.Log ("In to GetCards");
		foreach (int i in cardIdList) {
			Debug.Log ("In to cardIdList");
			foreach (GameObject j in drawCard.Cards) {
				Debug.Log ("In to drawCard.Cards");
				if (i == j.GetComponent<card_attribute> ().cardNum) {
					Debug.Log ("find the cards to draw");
					if (cardParent_refrence.transform.parent.childCount <= 6) {
						cardPrefab = j;
						GameObject cardCopy = (GameObject)Instantiate (cardPrefab);
						cardCopy.transform.SetParent (parent);
						cardCopy.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1f, 1f);
						cardCopy.transform.SetSiblingIndex (this.transform.GetSiblingIndex ());
						Debug.Log ("finish  GetCards");
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
		drawCard = GetComponent<DrawCard> ();
		Shuffle ();
		parent = cardParent_refrence.transform.parent;
		checkMyTurn ();
	}


	// Update is called once per frame
	void Update () {
	}

	public void checkMyTurn(){
		    Debug.Log ("In to checkMyTurn");
			todrawcard();
			this.GetComponent<dice>().throwdice ();
	}
		
	void todrawcard(){
		Debug.Log ("In to todrawcard");
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
