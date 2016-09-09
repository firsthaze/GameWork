using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showmasterHP : MonoBehaviour {
	public int masterHP;
	public Text text;
	// Use this for initialization
	void Start () {
		masterHP = 30;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "" + masterHP;
	}
}
