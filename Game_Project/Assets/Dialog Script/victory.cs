using UnityEngine;
using System.Collections;

public class victory : MonoBehaviour {
	public GameObject victoryPicture;
	public GameObject defeatPicture;
	// Use this for initialization
	void Start () {
		victoryPicture.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

	public IEnumerator victoryBoard(){
		victoryPicture.SetActive (true);
		yield return new WaitForSeconds (2);
		SceneLoader.ins.LoadLevel (SceneLoader.Scenes.finishScene);
	}

	public IEnumerator defeatBoard(){
		defeatPicture.SetActive (true);
		yield return new WaitForSeconds (2);
		SceneLoader.ins.LoadLevel (SceneLoader.Scenes.HomePage);
	}
}
