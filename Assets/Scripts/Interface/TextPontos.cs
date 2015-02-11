using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextPontos : MonoBehaviour {
	public PlayerJump pontos;
	float pon;
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(pontos.pontos >= pon)
		{
			pon += 0.1f;
		}
		else
		{
			pon = pontos.pontos;
		}
		text.text = ""+ (int)pon;
	}
}
