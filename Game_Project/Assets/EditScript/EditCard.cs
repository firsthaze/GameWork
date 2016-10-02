using UnityEngine;
using System.Collections;

public class EditCard : MonoBehaviour {
	
	GameObject thiscard;
	GameObject carddisplayzone;
	GameObject cardCopy;
	Transform parent;

	// Use this for initialization
	void Start () {
		thiscard = this.gameObject;
		carddisplayzone = GameObject.FindGameObjectWithTag("displaycardrefrence");
		parent = carddisplayzone.transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseUp(){
		if(carddisplayzone.transform.parent.childCount<7)
		displayCard ();
	}

	void displayCard(){
		cardCopy = (GameObject)Instantiate (thiscard);
		cardCopy.transform.SetParent (parent);
		cardCopy.GetComponent<RectTransform> ().localScale = new Vector3 (0.8f, 0.8f, 0.8f);
		cardCopy.transform.tag = "myHand";
	}
}
