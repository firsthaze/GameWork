using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class record_coordinate : MonoBehaviour {
	public int[] coordinate_x = new int[90];
	public int[] coordintae_z = new int[90];
	private Vector3 coordinateposition;
	private int _coordinate_x,_coordinate_y,_coordinate_z;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		record_cor ();
	}

	void record_cor(){

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				cor_process (hit.transform.position.x);
				cor_process (hit.transform.position.z);
				Debug.Log (cor_process (hit.transform.position.x));
				Debug.Log (cor_process (hit.transform.position.z));
			}
		}
	}

	int cor_process(float coordinate){
		if (coordinate > 0)
			return (int)coordinate + 1;
		else
			return (int)coordinate;
	}
}
