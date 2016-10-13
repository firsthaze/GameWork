using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Index))]
public class ClickFinish : MonoBehaviour {
	public static List<int> cardIndex;
	private string passCardIndex;
	private string token;
	public GameObject finsihBoard;

	// Use this for initialization
	void Start () {
		cardIndex = new List<int> ();
	}

	// Update is called once per frame
	void Update () {
	}

	public void OnClick(){
		CollectCard ();
	}

	public void BackToUI(){
		SceneLoader.ins.LoadLevel (SceneLoader.Scenes.HomePage);
	}

	void CollectCard(){
		cardIndex.Clear ();
		foreach (GameObject card in GameObject.FindGameObjectsWithTag("myHand")) {
			Debug.Log ("card is : " + card.GetComponent<card_attribute> ().cardNum);
			cardIndex.Add(card.GetComponent<card_attribute> ().cardNum);
			finsihBoard.SetActive (true);
			StartCoroutine (endBoard ());
		}
	}
	IEnumerator endBoard(){
		yield return new WaitForSeconds (2);
		finsihBoard.SetActive (false);
	}
}
