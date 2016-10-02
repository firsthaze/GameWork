using UnityEngine;
using System.Collections;
using SocketIO;
using UnityEngine.UI;

public class checkUserInfo : MonoBehaviour {
	public Text stoneNumber,myName;
	private string token;
	JSONObject newUser;
	GameObject socket;
	SocketIOComponent user;

	// Use this for initialization
	void Start () {
		socket = GameObject.FindGameObjectWithTag ("Socket");
		user = socket.GetComponent<SocketIOComponent> ();
		token = SystemInfo.deviceUniqueIdentifier;
		newUser = new JSONObject ();
		newUser.AddField ("token", token);
		checkMyStone ();
		checkMyName ();
	}
	
	// Update is called once per frame
	void Update () {
		user.On ("getMyStone", getMyStone);
		user.On ("getMyName", getMyName);
	}

	void checkMyStone(){
		user.Emit ("checkStone", newUser);
	}
	void checkMyName(){
		user.Emit ("checkMyName", newUser);
	}

	void getMyStone(SocketIOEvent e){
		stoneNumber.text = "" + e.data["stone"];
	}

	void getMyName(SocketIOEvent e){
		myName.text ="" +  e.data["Name"].str;
	}
}
