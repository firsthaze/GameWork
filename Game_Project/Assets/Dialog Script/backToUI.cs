using UnityEngine;
using System.Collections;

public class backToUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		StartCoroutine (goToUI ());
	}

	IEnumerator goToUI(){
		yield return  new WaitForSeconds (1);
		Application.LoadLevel (5);
	}
}
