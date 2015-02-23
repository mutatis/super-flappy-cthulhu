using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextPontos : MonoBehaviour 
{
	float pon;
	Text text;

	// Use this for initialization
	void Start () {
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
