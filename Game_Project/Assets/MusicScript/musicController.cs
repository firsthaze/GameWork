using UnityEngine;
using System.Collections;

public class musicController : MonoBehaviour {
	public AudioClip[] musics;
	AudioSource myAudioSource;
	AudioSource musicEffect;
	public float speed;
	/*
	 * 0:主畫面音樂
	 * 1:第一關背景音樂
	 * 2:第二關背景音樂
	 * 3:登入音樂
	 * 4:點擊音效
	 * 5.firstMovie背景音樂
	 * 6:喀拉喀拉聲音
	 * 7:恐怖背景音樂
	 * 8:攻擊音效
	 * 9:轉換回合
	 * 10:勝利音效
	 */

	public static musicController ins;

	void Awake(){

		if(ins == null){

			ins = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}else if(ins != this){
			Destroy(gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		myAudioSource = this.transform.GetChild (0).gameObject.GetComponent<AudioSource>();
		musicEffect = this.transform.GetChild (1).gameObject.GetComponent<AudioSource>();
		PlayBackGroundMusic (3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayBackGroundMusic(int musicClip){
		StartCoroutine(TurnOffMusic ());
		myAudioSource.clip = musics [musicClip];
		myAudioSource.Play ();
		myAudioSource.volume = 0.5f;
		myAudioSource.loop = true;
	}

	IEnumerator TurnOffMusic(){
		while (myAudioSource.volume > 0.01)
			myAudioSource.volume -= speed * 0.01f;
		myAudioSource.volume = 0;
		yield return new WaitForSeconds (0.5f);
	}
		

	public void ChoiceOneShot(int musicClip){
		musicEffect.clip = musics [musicClip];
		musicEffect.PlayOneShot (musicEffect.clip, 1f);
	}
}
