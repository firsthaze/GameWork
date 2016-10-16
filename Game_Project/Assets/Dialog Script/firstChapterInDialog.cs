using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class firstChapterInDialog : MonoBehaviour {
	int scene;
	GameObject musicControll;
	public Text characterName;
	public Text dialog;
	public GameObject character1,character2;

	// Use this for initialization
	void Start () {
		musicControll = GameObject.Find ("MusicController");
		musicControll.GetComponent<musicController> ().PlayBackGroundMusic (7);
		scene = 0;
		character1.SetActive (false);
		character2.SetActive (false);
		ShowStory (scene);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		musicControll.GetComponent<musicController> ().ChoiceOneShot(4);
		ShowStory (scene);
	}

	void ShowStory (int choosescene){
		switch (choosescene) {
		case 0:
			character1.SetActive (true);
			characterName.text = "???";
			dialog.text = "終於...";
			scene++;
			break;
		case 1:
			character1.SetActive (false);
			characterName.text = "";
			dialog.text = "望著眼前巨大的冰棺，神秘的人影不僅沒有感到絲毫的害怕，瞳孔的光芒甚至透露出難以名狀的興奮之情";
			scene++;
			break;
		case 2:
			characterName.text = "";
			dialog.text = "緩緩地，人影的右手撫上了冰棺，然而，就在觸碰到冰棺的那一剎那...";
			scene++;
			break;
		case 3:
			characterName.text = "";
			musicControll.GetComponent<musicController> ().ChoiceOneShot (6);
			dialog.text = "喀拉喀拉喀拉，從陰暗處裡，傳來了齒輪轉動的聲響，似乎有什麼被放了出來。";
			scene++;
			break;
		case 4:
			character1.SetActive (true);
			character2.SetActive (true);
			characterName.text = "???";
			dialog.text = "我就知道哪有這麼簡單的事......咖酷還再睡!該上工啦!";
			scene++;
			break;
		case 5:
			character1.SetActive (false);
			character2.SetActive (false);
			characterName.text = "";
			dialog.text = "語畢，人影的底下蔓延出紫色的光暈，頓時壟罩了整個空間。";
			scene++;
			break;
		case 6:
			character1.SetActive (true);
			characterName.text = "???";
			dialog.text = "兵域......開!";
			scene++;
			break;
		case 7:
			scene=0;
			SceneLoader.ins.LoadLevel(SceneLoader.Scenes.firstLevel);
			break;
		default :
			break;
		}
	}
}
