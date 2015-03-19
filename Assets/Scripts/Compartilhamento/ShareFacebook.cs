using UnityEngine;
using System.Collections;

public class ShareFacebook : MonoBehaviour {

	private const string FACEBOOK_APP_ID = "1523494497914409";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";
	public string linkParameter;
	public string nameParameter;
	public string captionParameter;
	string descriptionParameter;
	public string pictureParameter;
	public string redirectParameter;
	public int tipo;

	void Start()
	{
		if(tipo == 0)
		{
			descriptionParameter = "Eu ja consegui " + (PlayerPrefs.GetInt ("flappyS")) + " pontos";
		}
		else if(tipo == 1)
		{
			descriptionParameter = "Acabei de fazer " + (PlayerJump.player.pontos) + " pontos";
		}
	}

	public void ShareToFacebook ()
	{
		Application.OpenURL (FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
		                     "&link=" + WWW.EscapeURL(linkParameter) +
		                     "&name=" + WWW.EscapeURL(nameParameter) +
		                     "&caption=" + WWW.EscapeURL(captionParameter) + 
		                     "&description=" + WWW.EscapeURL(descriptionParameter) + 
		                     "&picture=" + WWW.EscapeURL(pictureParameter) + 
		                     "&redirect_uri=" + WWW.EscapeURL(redirectParameter));
	}
}
