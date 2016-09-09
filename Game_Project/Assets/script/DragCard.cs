using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragCard : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler{
	public int cardNum;
	public RectTransform Hand;
	public Vector3 v3_position;
	public GameObject summor_Monster;
	public enum Slot{ WEAPON ,MAGIC ,BUFF};
	public Slot typeOfItem = Slot.WEAPON;
	public Transform parentToReturnTo = null;
	GameObject placeholder = null;
	public bool isextand = true;
	GameObject eventsystems;

	public void OnBeginDrag( PointerEventData eventdata ){
		placeholder = new GameObject ();
		placeholder.transform.SetParent (this.transform.parent);
		LayoutElement le = placeholder.AddComponent<LayoutElement> ();
		le.preferredWidth = this.GetComponent<LayoutElement> ().preferredWidth;
		le.preferredHeight = this.GetComponent<LayoutElement> ().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;

		placeholder.transform.SetSiblingIndex (this.transform.GetSiblingIndex ());

		parentToReturnTo = this.transform.parent;
		this.transform.SetParent (this.transform.parent.parent);

		GetComponent<CanvasGroup> ().blocksRaycasts = false;


	}

	public void OnDrag( PointerEventData eventdata ){
		eventsystems = GameObject.FindGameObjectWithTag("eventsystem");
		this.transform.position = eventdata.position;
		//int newSiblingIndex = parentToReturnTo.transform.childCount;

		/*製作卡牌的換位 可能在牌庫編輯時使用
		for (int i = 0; i < parentToReturnTo.childCount; i++) {
			if (this.transform.position.x < parentToReturnTo.GetChild (i).position.x) {
				newSiblingIndex = i;
				if (placeholder.transform.GetSiblingIndex () < newSiblingIndex)
					newSiblingIndex--;

				break;
			}
		}*/
			eventsystems.GetComponent<controllHand> ().shrink ();
		

		//placeholder.transform.SetSiblingIndex (newSiblingIndex);

	}


	public void OnEndDrag( PointerEventData eventdata ){
		Destroy (placeholder);
		eventsystems.GetComponent<controllHand> ().expansion();
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		this.transform.SetParent (parentToReturnTo);
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.tag == "altar") {
				if (dice.sum >= this.GetComponent<card_attribute> ().cost) {
					dice.sum = dice.sum - this.GetComponent<card_attribute> ().cost;
					v3_position = new Vector3 (hit.transform.position.x + 0.08f, hit.transform.position.y + 6.8f, hit.transform.position.z);
					summor_Monster = Instantiate (summor_Monster, v3_position, Quaternion.identity) as GameObject;
					summor_Monster.GetComponent<recordWhichCard> ().cardNum = this.GetComponent<card_attribute> ().cardNum;
					summor_Monster.GetComponent<recordWhichCard> ().HP = this.GetComponent<card_attribute> ().HP;
					summor_Monster.GetComponent<recordWhichCard> ().ATK = this.GetComponent<card_attribute> ().ATK;
					summor_Monster.GetComponent<recordWhichCard> ().Cost = this.GetComponent<card_attribute> ().cost;
					this.gameObject.SetActive (false);
				    } 
				else {
					Debug.Log ("Doesnt have enough Mana");
					this.transform.SetParent (parentToReturnTo);
					this.transform.SetSiblingIndex (placeholder.transform.GetSiblingIndex ());
				    } 
				 } 
			else {
				Debug.Log ("Dont click the altar");
				this.transform.SetParent (parentToReturnTo);
				this.transform.SetSiblingIndex (placeholder.transform.GetSiblingIndex ());
				}
			}  
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

}
