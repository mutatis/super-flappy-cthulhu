using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class GPGDemo : MonoBehaviour
{
	public Text text;

	void Start()
	{
		PlayGamesPlatform.Activate();
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
			if(success)
			{
				text.text = "Logo";
			}
		});
	}

	public void Loggin()
	{
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
			if(success)
			{
				text.text = "Logo";
			}
		});
	}

	public void Lead()
	{
		Social.ReportScore(55, "CgkIsZ6ut68TEAIQAA", (bool success) => {
			if(success)
			{
				text.text = "FOI";
			}
		});
	}

	public void Show()
	{
		Social.ShowLeaderboardUI();
		//PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIsZ6ut68TEAIQAA");
	}
}