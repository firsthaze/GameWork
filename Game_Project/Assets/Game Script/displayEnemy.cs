using UnityEngine;
using System.Collections;

public class displayEnemy : MonoBehaviour {
	public GameObject eventsystem;
	public GameObject cardPrefab;
	GameObject cardCopy;
	GameObject carddisplayzone;
	Transform parent;
	// Use this for initialization
	void Start () {
		carddisplayzone = GameObject.FindGameObjectWithTag("displaycardrefrence");
		parent = carddisplayzone.transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		clickMonster ();
	}

	void clickMonster(){
		if (countLine.mode!=1){
		    if (Input.GetMouseButtonDown (0)) {
		  	    RaycastHit hit;
			    Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			    if (Physics.Raycast (ray, out hit)) {
				    if (hit.transform.tag == "enemyMonster") {
					    if (cardCopy != null) {
					    	Destroy (cardCopy);
					    	cardCopy = (GameObject)Instantiate (cardPrefab);
				    		cardCopy.transform.SetParent (parent);
				    		cardCopy.GetComponent<RectTransform> ().localScale = new Vector3 (1.6f, 1.6f, 1.6f);
				    		cardCopy.GetComponent<card_attribute> ().ATK = hit.transform.GetComponent<enemyAttribute> ().ATK;
					    	cardCopy.GetComponent<card_attribute> ().HP = hit.transform.GetComponent<enemyAttribute> ().HP;
					    } else {
						    cardCopy = (GameObject)Instantiate (cardPrefab);
						    cardCopy.transform.SetParent (parent);
						    cardCopy.GetComponent<RectTransform> ().localScale = new Vector3 (1.6f, 1.6f, 1.6f);
						    cardCopy.GetComponent<card_attribute> ().ATK = hit.transform.GetComponent<enemyAttribute> ().ATK;
						    cardCopy.GetComponent<card_attribute> ().HP = hit.transform.GetComponent<enemyAttribute> ().HP;
					    }
				    } else {
					if (cardCopy != null)
						Destroy (cardCopy);
				    }
			    }
		    } else if (Input.GetMouseButtonUp (0)) {
			    if (cardCopy != null)
				Destroy (cardCopy);
		    }
	    }
	}
}
