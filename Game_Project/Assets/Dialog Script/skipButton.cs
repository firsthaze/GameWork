using UnityEngine;
using System.Collections;

public class skipButton : MonoBehaviour {
	public int loadlevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		Application.LoadLevel (loadlevel);
	}
}
