using UnityEngine;
using System.Collections;

public class recordWhichCard : MonoBehaviour{
	public int HP, ATK,Cost,cardNum,atkChance;
	//TODO:記錄這個物件是哪一張牌
	void Update(){
		checkHP ();
	}

	void checkHP(){
		if (HP <= 0)
			Destroy (this.gameObject);
	}
	// Use this for initialization

	/*顯示一張卡，暫時用不到
	public void displayCard(){
		foreach (GameObject j in drawCard.Cards) {
			if (cardNum == j.GetComponent<card_attribute> ().cardNum) {
				Debug.Log ("有找到卡片" + j);
				cardPrefab = j;
				cardCopy = (GameObject)Instantiate (cardPrefab);
				cardCopy.transform.SetParent (parent);
				cardCopy.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1f, 1f);
			}
			else{
				Debug.Log ("沒找到卡片");
			}
		}

	}

	public void exitCard (){
		Destroy (cardCopy);
	}
	*/

}
