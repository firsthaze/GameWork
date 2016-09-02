using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class end_phase : MonoBehaviour {
	public bool ismyturn;
	public static int phase_check;
	// Use this for initialization
	void Start () {
		ismyturn = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		ismyturn = true;
		Debug.Log("Phase finish , Now ,It,s your turn!");
		phase_check = 0;
	}
}
