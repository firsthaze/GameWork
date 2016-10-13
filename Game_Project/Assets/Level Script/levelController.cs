using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelController : MonoBehaviour {
	private GameObject thisController;
	public int nowLevel = 0;
	GameObject[] AllLevels;
	public bool isOpen;
	public static levelController ins;

	void Awake(){

		if(ins == null){
			ins = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}else if(ins != this){
			Destroy(gameObject);
		}
	} 

	void Start(){
		isOpen = false;
	}

	void Update(){
		if (isOpen) {
			StartCoroutine (spaceTime ());
			openNewLevel ();
		}
	}

	public IEnumerator spaceTime(){
		yield return new WaitForSeconds (1);
	}

	public void openNewLevel(){
		AllLevels = GameObject.FindGameObjectsWithTag ("level");
		Debug.Log ("into newLevel");
		Transform newLevelLine = AllLevels [nowLevel].transform.GetChild (0);
		newLevelLine.gameObject.SetActive (true);
		newLevelLine = AllLevels [nowLevel].transform.GetChild (1);
		newLevelLine.gameObject.GetComponent<Button> ().enabled = true;
		isOpen = false;
	}
}
