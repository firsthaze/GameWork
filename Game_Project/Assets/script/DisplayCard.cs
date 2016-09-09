using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DisplayCard : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler {
	GameObject thiscard;
	GameObject carddisplayzone;
	GameObject cardCopy;
	Transform parent;

	// Use this for initialization
	void Start () {
		carddisplayzone = GameObject.FindGameObjectWithTag("displaycardrefrence");
		parent = carddisplayzone.transform.parent;
		thiscard = this.gameObject;
	}
		
	public void OnPointerEnter(PointerEventData eventData){
		if (carddisplayzone.transform.parent.childCount==1) {
			displayCard ();
		}
	}

	public void OnPointerExit(PointerEventData eventData){
		exitCard ();
	}

	void displayCard(){
		cardCopy = (GameObject)Instantiate (thiscard);
		cardCopy.transform.SetParent (parent);
		cardCopy.GetComponent<RectTransform> ().localScale = new Vector3 (1.6f, 1.6f, 1.6f);
	}

	void exitCard(){
		Destroy (cardCopy);
	}

}
