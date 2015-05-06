using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class TextPontos : MonoBehaviour 
{
	float pon;
	Text text;
	float soma = 0.1f;
	public AudioSource audios;
	public AudioClip bate;

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
			AudioSource.PlayClipAtPoint(bate, new Vector3(transform.position.x, transform.position.y, transform.position.z));
			audios.Stop();
			pon = PlayerJump.player.pontos;
			Social.ReportScore(PlayerPrefs.GetInt("flappyS"), "CgkIsZ6ut68TEAIQAA", (bool success) => {
				
			});
		}
		if(Input.GetMouseButtonDown(0))
		{
			AudioSource.PlayClipAtPoint(bate, new Vector3(transform.position.x, transform.position.y, transform.position.z));
			audios.Stop();
			pon = PlayerJump.player.pontos;
			Social.ReportScore(PlayerPrefs.GetInt("flappyS"), "CgkIsZ6ut68TEAIQAA", (bool success) => {
				
			});
		}
		text.text = ""+ (int)pon;
	}
}
