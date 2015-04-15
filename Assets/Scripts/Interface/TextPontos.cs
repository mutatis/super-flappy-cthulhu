using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextPontos : MonoBehaviour 
{
	float pon;
	Text text;
	float soma = 0.1f;

	// Use this for initialization
	void Start () 
	{
#if UNITY_IOS
		soma *= 2;
#endif
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerJump.player.pontos >= pon)
		{
			pon += 0.1f;
		}
		else
		{
			pon = PlayerJump.player.pontos;
		}
		text.text = ""+ (int)pon;
	}
}
