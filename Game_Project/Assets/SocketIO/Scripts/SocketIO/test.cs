using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SocketIO;

public class test : MonoBehaviour {
	SocketIOComponent hi;
	// Use this for initialization
	void Start () {
		hi = GetComponent<SocketIOComponent> ();
		hi.On ("hi2", HI);
	}
	
	// Update is called once per frame
	void Update () {
		Dictionary<string,string> d = new Dictionary<string,string> ();
		d.Add("data", "hi");
		d.Add("data2", "hi");
		d.Add("data3", "hi");
		JSONObject j = new JSONObject (d);
		hi.Emit ("hi", j);
	}

	private void HI(SocketIOEvent e){
		Debug.Log(e.data["message"].n);
	}
		
}
