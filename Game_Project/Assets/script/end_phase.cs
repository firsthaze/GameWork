using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class end_phase : MonoBehaviour {
	public bool ismyturn;
	public static int phase_check;
	GameObject eventSystem;
	GameObject buttonEndPhase;
	// Use this for initialization
	void Start () {
		ismyturn = true;
		eventSystem = GameObject.FindGameObjectWithTag ("eventsystem");
		buttonEndPhase = GameObject.Find ("finish_phase");
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnClick(){
		ismyturn = false;
		eventSystem.GetComponent<MyTurn> ().checkMyTurn ();
		GetComponent<enemy_phase> ().checkMyTurn ();
		Debug.Log("Phase finish , Now ,It,s your turn!");
		phase_check = 0;
		buttonEndPhase.GetComponent<Button> ().interactable = false;
    }
}