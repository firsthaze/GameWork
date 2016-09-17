using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class messageController : MonoBehaviour {
	public Text messageView;
	string tmp;
	// Use this for initialization
	void Start () {
		receiveMessage (0);
	}
		

	// Update is called once per frame
	void Update () {
	}

	/* TODO:

	  case 1 :輪到Master的回合。
	  case 2 :輪到敵軍的回合。
	  case 3 :Master沒有兵棋囉!
	  case 4 :Master需要更多的Mana!
	  case 5 :Master沒有放到祭壇上喔!
	  case 6 :Master正受到攻擊!請盡快建立防線!
	  case 7 :該兵棋已經行動過囉!
	  
    */

	public void receiveMessage(int messageModel){
		switch (messageModel) {
		case 0:
			tmp = "等待飛鴿傳書中......";
			StartCoroutine (changeMessage ());
			break;
		case 1:
			tmp = "輪到Master的回合。";
			StartCoroutine (changeMessage ());
			break;
		case 2:
			tmp = "輪到敵軍的回合。";
			StartCoroutine (changeMessage ());
			break;
		case 3:
			tmp = "Master沒有手牌囉!";
			StartCoroutine (changeMessage ());
			break;
		case 4:
			tmp = "Master需要更多的    Mana!。";
			StartCoroutine (changeMessage ());
			break;
		case 5:
			tmp = "Master沒有放到祭壇上喔!";
			StartCoroutine (changeMessage ());
			break;
		case 6:
			tmp = "Master正受到攻擊!請盡快建立防線!";
			StartCoroutine (changeMessage ());
			break;
		case 7:
			tmp = "該兵棋已經行動過囉!";
			StartCoroutine (changeMessage ());
			break;
		default:
			tmp = "等待飛鴿傳書中......";
			StartCoroutine (changeMessage ());
			break;
		}
	}

	IEnumerator changeMessage(){
		messageView.text = tmp;
		yield return new WaitForSeconds (0);
	}
}
