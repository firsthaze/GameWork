using UnityEngine;
using System.Collections;

public class startView : MonoBehaviour {

	IEnumerator OnMouseDown(){
		StartCoroutine (this.GetComponent<sceneFade> ().FadeOut ());
		yield return new WaitForSeconds (2);
		ChangeView ();
	}
	void ChangeView(){
		Application.LoadLevel (1);
	}
}
