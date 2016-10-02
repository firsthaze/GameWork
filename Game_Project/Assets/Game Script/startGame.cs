using UnityEngine;
using System.Collections;
using SocketIO;

public class startGame : MonoBehaviour {
	private string token;
	JSONObject newUser;
	public GameObject socket;
	SocketIOComponent user;
	// Use this for initialization
	void Start () {
		user = socket.GetComponent<SocketIOComponent> ();
		DontDestroyOnLoad (socket);
		token = SystemInfo.deviceUniqueIdentifier;
		newUser = new JSONObject ();
		newUser.AddField ("token", token);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown() {
		user.Emit ("login", newUser);
		SceneLoader.ins.LoadLevel (SceneLoader.Scenes.HomePage);
	}
}
