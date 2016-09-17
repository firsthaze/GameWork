using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class firstChapterInDialog : MonoBehaviour {
	int screen;
	public Text characterName;
	public Text dialog;

	// Use this for initialization
	void Start () {
		screen = 0;
		ShowStory (screen);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		ShowStory (screen);
	}

	void ShowStory (int chooseScreen){
		switch (chooseScreen) {
		case 0:
			characterName.text = "???";
			dialog.text = "終於...";
			screen++;
			break;
		case 1:
			characterName.text = "";
			dialog.text = "望著眼前巨大的冰棺，神秘的人影不僅沒有感到絲毫的害怕，瞳孔的光芒甚至透露出難以名狀的興奮之情";
			screen++;
			break;
		case 2:
			characterName.text = "";
			dialog.text = "緩緩地，人影的右手撫上了冰棺，然而，就在觸碰到冰棺的那一剎那...";
			screen++;
			break;
		case 3:
			characterName.text = "";
			dialog.text = "喀拉喀拉喀拉，從四周角落的陰暗處，傳來了互相碰撞的聲響。";
			screen++;
			break;
		case 4:
			characterName.text = "???";
			dialog.text = "我就知道哪有這麼簡單的事......咖酷還再睡!該上工啦!";
			screen++;
			break;
		case 5:
			characterName.text = "";
			dialog.text = "語畢，人影的底下蔓延出藍色的光暈，頓時壟罩了整個空間。";
			screen++;
			break;
		case 6:
			characterName.text = "???";
			dialog.text = "兵域......開!";
			screen++;
			break;
		case 7:
			Application.LoadLevel (3);
			screen=0;
			break;
		default :
			break;
		}
	}
}
