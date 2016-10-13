using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	public RectTransform movePicture;
	// Use this for initialization
	void Start () {
		StartCoroutine(ToMoveUp());
	}
	void FixedUpdate(){
	}

	IEnumerator ToMoveUp(){
		movePicture.position = new Vector3 (movePicture.transform.position.x, 40f, movePicture.transform.position.z);
		yield return new WaitForSeconds (0.5f);
		StartCoroutine (ToMoveDown ());
	}

	IEnumerator ToMoveDown(){
		movePicture.position = new Vector3 (movePicture.transform.position.x, 35f, movePicture.transform.position.z);
		yield return new WaitForSeconds (0.5f);
		StartCoroutine (ToMoveUp ());
	}
}
