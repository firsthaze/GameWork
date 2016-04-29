using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class terrritoy_mouse_ver2 : MonoBehaviour {
    public GameObject go;
	bool flag;
	public Texture mouse_Picture;
	public Vector2 mouse_Position;


	// Use this for initialization
	void Start () {
		go = GameObject.Find("terrtitory_button");
		flag = go.GetComponent<territory_Click>().territory_isClick;
		if (flag) {
			Debug.Log("Sucess");
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (flag) {
			Cursor.visible = false;
			mouse_Position = Input.mousePosition;
			GUI.DrawTexture (new Rect (mouse_Position.x, Screen.height - mouse_Position.y, 16, 20), mouse_Picture);
		}

	}
		
}
