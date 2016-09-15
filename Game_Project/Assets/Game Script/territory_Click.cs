using UnityEngine;
using System.Collections;

public class territory_Click : MonoBehaviour {
	public bool territory_isClick;
	// Use this for initialization
	void Start () {
		territory_isClick = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		territory_isClick = true;
		if (dice.sum <= 1) {
			territory_isClick = false;
			Cursor.visible = true;
		}
		else	
		dice.sum = dice.sum - 2;

	}
}
