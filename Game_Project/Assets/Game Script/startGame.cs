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
		user.On ("isExist", GoToWhere);
	}

	void OnMouseDown() {
		user.Emit ("login", newUser);
	}

	void GoToWhere(SocketIOEvent e){
		if (!e.data ["isExist"].b)
			SceneLoader.ins.LoadLevel (SceneLoader.Scenes.firstMovieScene);
		else if(e.data ["isExist"].b)
			SceneLoader.ins.LoadLevel (SceneLoader.Scenes.HomePage);
	}
}
