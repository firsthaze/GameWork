using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollCard : MonoBehaviour {
	public RectTransform panel; //To hold the scrollpanel
	public GameObject[] Cards;
	public RectTransform center; //TO compare with each card

	private float[] distance;
	private bool dragging = false;
	private int cardDistance;
	private int minCardNum;

	void Start(){
		foreach (GameObject card in Cards) {
			card.GetComponent<DragCard> ().enabled = false;
		}		
		int cardLength = Cards.Length;
		distance = new float[cardLength];

		cardDistance = (int)Mathf.Abs (Cards [1].GetComponent<RectTransform> ().anchoredPosition.x - Cards [0].GetComponent<RectTransform> ().anchoredPosition.x);
	}

	void Update(){
		for (int i = 0; i < Cards.Length; i++) {
			distance [i] = Mathf.Abs (center.transform.position.x - Cards [i].transform.position.x);
		}

		float minDistance = Mathf.Min (distance);

		for (int a = 0; a < Cards.Length; a++) {
			if (minDistance == distance [a]) {
				minCardNum = a;
			}
		}

		if (!dragging) {
			LerpToCard (minCardNum * -cardDistance);
		}
	}

	void LerpToCard(int position){
		float newX = Mathf.Lerp (panel.anchoredPosition.x, position, Time.deltaTime * 3f);
		Vector2 newPosition = new Vector2 (newX, panel.anchoredPosition.y);

		panel.anchoredPosition = newPosition;
	}

	public void StartDrag(){
		dragging = true;
	}

	public void EndDrag(){
		dragging = false;
	}
}
