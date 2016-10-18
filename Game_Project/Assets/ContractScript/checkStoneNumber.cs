using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SocketIO;

public class checkStoneNumber : MonoBehaviour {
	public Text stoneNumber;
	private string token;
	public float stone;
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
	}

	// Update is called once per frame
	void Update () {
		user.On ("getMyStone", getMyStone);
	}

	public void checkMyStone(){
		user.Emit ("checkStone", newUser);
	}
	void getMyStone(SocketIOEvent e){
		stoneNumber.text = "" + e.data["stone"];
		stone = e.data["stone"].f;
	}
}
