using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mana : MonoBehaviour {
	public Text text;
	// Use this for initialization
	void Start () {
		
	
	}
	void count(){
			
	}
	// Update is called once per frame
	void Update () {
			
		text.text = " " + dice.sum + "  mana";
		    
	}

    
}
