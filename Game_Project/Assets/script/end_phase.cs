using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class end_phase : MonoBehaviour {
	public static int phase_check;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		if(end_phase.phase_check ==2)
		Debug.Log("Phase finish , Now ,It,s your turn!");
		phase_check = 0;
	}
}
