using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dice : MonoBehaviour {
	int mana_i = 0;
	public static int sum;
	float mana_f = 0f;
	// Use this for initialization
	void Start () {
		sum = 0;	
	
	}
	
	// Update is called once per frame
	void Update () {
		if (sum <= 12)
			sum = sum;
		else {
			sum = 12;

		}
	}

	public void throwdice()
	{
			mana_f = Random.Range (1.0f, 7.0f);
			mana_i = (int)mana_f;
			sum = sum + mana_i;
	}
}
