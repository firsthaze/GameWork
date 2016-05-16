using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class count_hp : MonoBehaviour {
	private int _hp;
	public static int _cnt_tower;
	public Text text;
	// Use this for initialization
	void Start () {
		_hp = 30;
		_cnt_tower = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (end_phase.phase_check == 0) {
			_hp = _hp - _cnt_tower;
			text.text = " "+_hp;
			end_phase.phase_check = 1;
		}
	}
}
