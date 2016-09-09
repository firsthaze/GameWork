using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class test : MonoBehaviour {
	void show(){
	if(Input.GetMouseButtonDown (0)) {
		RaycastHit hit2;
		Ray ray2 = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray2, out hit2)) {
				if(hit2.transform.tag =="Player")
				Debug.Log ("hit the Player");

		}
	  }
	}
}
