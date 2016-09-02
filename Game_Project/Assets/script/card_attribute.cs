using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class card_attribute : MonoBehaviour {
	public int cardNum;
	public int HP, ATK,cost;
	public Text hp_num,atk_num,cost_num;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		hp_num.text = ""+HP;
		atk_num.text =""+ ATK;
		cost_num.text = ""+cost;
	}



}
