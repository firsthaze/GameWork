using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class terrritoy_mouse_ver2 : MonoBehaviour {
    public GameObject go;
	public GameObject create_tower;
	public Texture mouse_Picture;
	public Vector2 mouse_Position;
	public Vector3 v3_position;
	private bool flag;     //不能連續點擊的開關
	private bool _isexist; //不能同地點建造的開關





	// Use this for initialization
	void Start () {
		flag = false;
		_isexist = false;
	}
	
	// Update is called once per frame
	void Update () {
		HitCoordinate();
	}



	void HitCoordinate(){
		if (flag) {
			if (Input.GetMouseButtonDown (0)) {
				flag = false;
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider.tag == "tower") {
						Debug.Log("hit the same site");
					} 

					else if (hit.collider.tag == "altar") {
						Debug.Log("hit the altar");
					} 
					else {
						Cursor.visible = true;
						v3_position = new Vector3 (hit.transform.position.x + 0.7f, hit.transform.position.y - 0.1f, hit.transform.position.z + 0.2f);
						create_tower = Instantiate (create_tower, v3_position, Quaternion.identity) as GameObject;
						go.GetComponent<territory_Click> ().territory_isClick = false;
						count_hp._cnt_tower = count_hp._cnt_tower + 1;
					}
				}
			}
		}
	}

    void OnGUI(){
		if (go.GetComponent<territory_Click>().territory_isClick) {
			    flag = true;
			    Cursor.visible = false;
				mouse_Position = Input.mousePosition;
				GUI.DrawTexture (new Rect (mouse_Position.x, Screen.height - mouse_Position.y, 30, 40), mouse_Picture);
				if (Input.GetMouseButtonDown (1)) {
					Cursor.visible = true;
					dice.sum = dice.sum + 2;
					go.GetComponent<territory_Click> ().territory_isClick = false;
				}
  
		}
	}
}
