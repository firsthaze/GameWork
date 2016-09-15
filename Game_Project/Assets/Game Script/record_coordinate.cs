using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class record_coordinate : MonoBehaviour {
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
				if (hit.transform.tag == "coordinate") {
					cor_process (hit.transform.position.x);
					cor_process (hit.transform.position.z);
					Debug.Log ("X :" + cor_process (hit.transform.position.x));
					Debug.Log ("Y :" + cor_process (hit.transform.position.z));
				}
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
