using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class firstMovie : MonoBehaviour
{
	GameObject musicControll;
	GameObject sceneFade;
	public Text dialog;
	int screen;
	// Use this for initialization
	void Start ()
	{
		musicControll = GameObject.Find ("MusicController");
		musicControll.GetComponent<musicController> ().PlayBackGroundMusic (5);
		this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		sceneFade = GameObject.Find ("SceneFade");
		screen = 0;
		ShowStory (screen);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	IEnumerator OnMouseDown ()
	{
		musicControll.GetComponent<musicController> ().ChoiceOneShot(4);
		StartCoroutine (sceneFade.GetComponent<sceneFade> ().FadeOut ());
		yield return new WaitForSeconds (1);
		if (screen > 3) {
			SceneLoader.ins.LoadLevel(SceneLoader.Scenes.chapter1Dialog);
		} else {
			StartCoroutine (sceneFade.GetComponent<sceneFade> ().FadeIn ());
			ShowStory (screen);
		}
	}

	void ShowStory (int chooseScreen)
	{
		switch (chooseScreen) {
		case 0:
			StartCoroutine (sceneFade.GetComponent<sceneFade> ().FadeIn ());
			dialog.text = "「人有七宗罪啊，葬於七都呦......暴食冰玉顏啊，怠惰智絕天......」";
			screen++;
			break;
		case 1:
			dialog.text = "這是洛克亞大陸上，吟遊詩人四處傳唱的歌謠，各地的小朋友都會不時地哼著";
			screen++;
			break;
		case 2:
			dialog.text = "只是......";
			screen++;
			break;
		case 3:
			dialog.text = "或許大家都遺忘了，它們，曾不僅僅只是傳說......";
			screen++;
			break;
		default:
			break;

		}
	}

}
