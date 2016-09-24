using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changePicture : MonoBehaviour {
	public GameObject[] toActivePicture;
	public GameObject changeAnimate;
	public Text cost,hp,atk;
	private int cardNumber = 0;
	public float speed;
	// Use this for initialization
	void Start () {
		StartCoroutine( changeCharacter ());
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator changeCharacter(){
		switch (cardNumber) {
		case 0:
			//saber_blue:回合結束回復3點血
			toActivePicture [cardNumber].SetActive (true);
			cost.text = "" + 10;
			hp.text = "" + 6;
			atk.text = "" + 6;
			yield return new WaitForSeconds (3);
			toActivePicture [cardNumber].SetActive (false);
			cardNumber++;
			StartCoroutine( changeCharacter ());
			break;
		case 1:
			//archer_Red:我方回合結束直接對玩家產生4點傷害
			toActivePicture [cardNumber].SetActive (true);
			cost.text = "" + 4;
			hp.text = "" + 4;
			atk.text = "" + 2;
			yield return new WaitForSeconds (3);
			toActivePicture [cardNumber].SetActive (false);
			cardNumber++;
			StartCoroutine( changeCharacter ());
			break;
		case 2:
			//assassin_black:??
			toActivePicture [cardNumber].SetActive (true);
			cost.text = "" + 3;
			hp.text = "" + 3;
			atk.text = "" + 4;
			yield return new WaitForSeconds (3);
			toActivePicture [cardNumber].SetActive (false);
			cardNumber++;
			StartCoroutine( changeCharacter ());
			break;
		case 3:
			//saber_white:??
			toActivePicture [cardNumber].SetActive (true);
			cost.text = "" + 8;
			hp.text = "" + 8;
			atk.text = "" + 8;
			yield return new WaitForSeconds (3);
			toActivePicture [cardNumber].SetActive (false);
			cardNumber++;
			StartCoroutine( changeCharacter ());
			break;
		case 4:
			//archer_pink:??
			toActivePicture [cardNumber].SetActive (true);
			cost.text = "" + 5;
			hp.text = "" + 3;
			atk.text = "" + 4;
			yield return new WaitForSeconds (3);
			toActivePicture [cardNumber].SetActive (false);
			cardNumber++;
			StartCoroutine( changeCharacter ());
			break;
		case 5:
			//assassin_blue:??
			toActivePicture [cardNumber].SetActive (true);
			cost.text = "" + 3;
			hp.text = "" + 2;
			atk.text = "" + 5;
			yield return new WaitForSeconds (3);
			toActivePicture [cardNumber].SetActive (false);
			cardNumber++;
			StartCoroutine( changeCharacter ());
			break;
		case 6:
			//saber_purple:攻擊機會3次
			toActivePicture [cardNumber].SetActive (true);
			cost.text = "" + 4;
			hp.text = "" + 4;
			atk.text = "" + 2;
			yield return new WaitForSeconds (3);
			toActivePicture [cardNumber].SetActive (false);
			cardNumber++;
			StartCoroutine( changeCharacter ());
			break;
		case 7:
			//archer_yellow??
			toActivePicture [cardNumber].SetActive (true);
			cost.text = "" + 1;
			hp.text = "" + 3;
			atk.text = "" + 3;
			yield return new WaitForSeconds (3);
			toActivePicture [cardNumber].SetActive (false);
			cardNumber++;
			StartCoroutine( changeCharacter ());
			break;
		case 8:
			//assassin_purple:每次攻擊主角回復攻擊力的一半
			toActivePicture [cardNumber].SetActive (true);
			cost.text = "" + 4;
			hp.text = "" + 3;
			atk.text = "" + 4;
			yield return new WaitForSeconds (3);
			toActivePicture [cardNumber].SetActive (false);
			cardNumber = 0;
			StartCoroutine( changeCharacter ());
			break;
		default :
			break;
		}
	}

	void fadeIn(){
		for (float countDown = 1f; countDown > 0; countDown -= Time.deltaTime) {
			changeAnimate.GetComponent<RectTransform> ().localScale = new Vector3 (1f - speed * Time.deltaTime, 1f - speed * Time.deltaTime, 0f);
		}
		changeAnimate.GetComponent<RectTransform> ().localScale = new Vector3 (0f, 0f, 0f);
	}

	void fadeOut(){
		for (float countDown = 1f; countDown > 0; countDown -= Time.deltaTime) {
			changeAnimate.GetComponent<RectTransform> ().localScale = new Vector3 (speed * Time.deltaTime, speed * Time.deltaTime, 0f);
		}
		changeAnimate.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1f, 0f);
	}
}
