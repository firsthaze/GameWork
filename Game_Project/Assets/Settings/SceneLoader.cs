using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {
	public Scenes own;
	public enum Scenes{

		startGame = 0,
		firstMovieScene,
		chapter1Dialog,
		firstLevel,
		finishScene,
		HomePage,
		ContractUI,
		Edit
	}

	public static SceneLoader ins;

	void Awake(){

		if(ins == null){

			ins = this;
			GameObject.DontDestroyOnLoad(gameObject);
			SceneManager.ins.OwnSecne = (int)this.own;
		}else if(ins != this){

			Destroy(gameObject);
		}
	}

	public void LoadLevel(Scenes target){
		SceneManager.ins.LoadScene((int)target);
	}
}
