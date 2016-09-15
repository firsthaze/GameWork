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
			dialog.text = "望著眼前巨大的冰棺，神秘的人影不僅沒有感到絲毫的害怕，瞳孔的光芒甚至透露出難以名狀的興奮之情";
			screen++;
			break;
		case 2:
			dialog.text = "望著眼前巨大的冰棺，神秘的人影不僅沒有感到絲毫的害怕，瞳孔的光芒甚至透露出難以名狀的興奮之情";
			screen++;
			break;
		case 3:
			dialog.text = "緩緩地，人影的右手撫上了冰棺，然而，就在觸碰到冰棺的那一剎那...";
			screen++;
			break;
		default :
			break;
		}
	}
}
