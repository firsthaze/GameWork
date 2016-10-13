using UnityEngine;
using System.Collections;

public class backToHome : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToHome(){
		SceneLoader.ins.LoadLevel (SceneLoader.Scenes.HomePage);
	}
}
