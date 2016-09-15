using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class level1 : MonoBehaviour {
	GameObject eventSystem;
	// Use this for initialization
	void Start () {
		eventSystem = GameObject.Find ("EventSystem");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		eventSystem.GetComponent<controlLevel> ().goToLevel (0);
	}
}
