using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controlLevel : MonoBehaviour {
	GameObject LevelPassAndControll;
	// Use this for initialization
	void Start () {
		LevelPassAndControll = GameObject.Find ("LevelPassAndControll");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToContract(){
		SceneLoader.ins.LoadLevel (SceneLoader.Scenes.ContractUI);
	}

	public void GoToEdit(){
		SceneLoader.ins.LoadLevel (SceneLoader.Scenes.Edit);
	}

	public void GoToLevel1(){
		LevelPassAndControll.GetComponent<levelController> ().nowLevel = 0;
		SceneLoader.ins.LoadLevel (SceneLoader.Scenes.firstLevel);
	}
}
