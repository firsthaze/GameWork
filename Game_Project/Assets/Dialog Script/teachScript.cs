using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class teachScript : MonoBehaviour {
	public GameObject teachBoard,nextButton,preButton;
	int page;
	public Text teachContext;
	public Text pageDisplay;

	// Use this for initialization
	void Start () {
		page = 1;
		ShowTeachContext (page);
	}
	
	// Update is called once per frame
	void Update () {
		pageDisplay.text = page + " / 9" ;
	}

	void ShowTeachContext(int changeContext){
		switch (changeContext) {
		case 1:
			teachContext.text = "各位Master好啊，我就是咖庫!接下來呢，由我向各位   Master解釋有關這個領域-「兵域」的事情!";
			preButton.SetActive (false);
			break;
		case 2:
			teachContext.text = "首先,Master可以觀看下面的部分,這是兵師的「兵譜」!每個回合兵譜都會補充一張兵棋，上限是6張，兵棋左上是職業別，右上是召喚兵棋需要的魔力，通稱Mana，左下是攻擊力，右下是生命力，劃過去就可以看得更清楚?";
			preButton.SetActive (true);
			break;
		case 3:
			teachContext.text = "如果覺得戰場看不清楚的話，可以點擊一旁的「捲起」，就可以把兵譜先收起來囉!點擊「攤開」的話，就可以把兵譜再次攤開喔";
			break;
		case 4:
			teachContext.text = "右邊的部分可以觀察到有Mana計數器，還有防禦塔，每回合Master的魔力都會隨機恢復1~6點，最高累積到12點。至於防禦塔的話，" +
				"每回合可以蓋一次，消耗2個Mana。結束回合後就換敵軍囉!";
			break;
		case 5:
			teachContext.text = "現在呢，就來到有關戰鬥方面的說明囉，在講每個兵職的特性之前，要先來說明一下有關這個戰場的「線位」的這個規則!";
			break;
		case 6:
			teachContext.text = "線位就是指該兵棋與敵方目標之前是否有其他敵方單位，如果沒有，就是1線，若有，則算是第2線，附帶一提，同一列都算是同一線喔!";
			break;
		case 7:
			teachContext.text = "可以來說說職業特性啦，目前呢，有三種兵職，分別為:  Saber、Assasin 和 Archer ! ";
			break;
		case 8:
			teachContext.text = "Saber的特性是每次攻擊成功，攻擊力都會上升一點，   Assasin是第一次攻擊時會造成兩倍傷害，             Archer則是可以越1個線位攻擊!";
			nextButton.SetActive (true);
			break;
		case 9:
			teachContext.text = "沒有看仔細的話記得再往前看喔，關掉之後就看不到囉咖酷的說明就到此結束，咖酷下台一鞠躬!";
			nextButton.SetActive (false);
			break;
		default :
			break;
		}
	}

	public void ClickClose(){
		Destroy (teachBoard);
	}

	public void ClickNext(){
		page++;
		ShowTeachContext (page);
	}

	public void ClickPre(){
		page--;
		ShowTeachContext (page);
	}
}
