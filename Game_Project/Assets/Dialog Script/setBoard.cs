using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class setBoard : MonoBehaviour {
	GameObject levelController;   //抓關卡
	public GameObject teachBoard;
	public GameObject settingBoard;
	public Text showLevel;
	// Use this for initialization
	void Start () {
		levelController = GameObject.Find ("LevelPassAndControll");
		showLevel.text = "Now Level :" + (levelController.GetComponent<levelController> ().nowLevel + 1);
	}

	public void QuitGame(){
		SceneLoader.ins.LoadLevel (SceneLoader.Scenes.HomePage);
	}

	public void CountineGame(){
		settingBoard.SetActive (false);
	}

	public void OpenSetBoard(){
		settingBoard.SetActive (true);
	}

	public void OpenTeachBoard(){
		teachBoard.SetActive (true);
		settingBoard.SetActive (false);
	}
}
