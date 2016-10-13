using UnityEngine;
using System.Collections;
using SocketIO;
public class backToUI : MonoBehaviour {
	private string token;
	JSONObject newUser;
	GameObject socket;
	SocketIOComponent user;
	GameObject openlevel;
	// Use this for initialization
	void Start () {
		openlevel = GameObject.Find ("LevelPassAndControll");
		socket = GameObject.FindGameObjectWithTag ("Socket");
		user = socket.GetComponent<SocketIOComponent> ();
		token = SystemInfo.deviceUniqueIdentifier;
		newUser = new JSONObject ();
		newUser.AddField ("token", token);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		user.Emit ("GetStone", newUser);
		goToUI ();
	}

    void goToUI(){
		openlevel.GetComponent<levelController> ().isOpen = true;
		SceneLoader.ins.LoadLevel (SceneLoader.Scenes.HomePage);
	}
}
