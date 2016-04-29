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
		if(dice.sum>=2)
			dice.sum = dice.sum - 2;
		territory_isClick = true;
	}
}
