using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class controllHand : MonoBehaviour {

	// pulic info
	public Button scrollHand;    // click to controll scroll
	public Text text;            // To show button is extand or not
	public RectTransform Hand;   // To hold the scroll pannel
	public bool isextand = true;  // judge the pannel is need scroll

	public void Onclick(){
		if (isextand) {
			shrink();
		} 
		else {
			expansion ();
		}
	}

	public void shrink(){
		isextand = false;
		float newx = -1150f;
		Vector2 outposition = new Vector2 (newx, Hand.anchoredPosition.y);
		Hand.anchoredPosition = outposition;
		text.text = "展開";
	}

	public void expansion(){
		isextand = true;
		float newx = 0f;
		Vector2 outposition = new Vector2 (newx, Hand.anchoredPosition.y);
		Hand.anchoredPosition = outposition;
		text.text = "收縮";
	}
		
	


}
