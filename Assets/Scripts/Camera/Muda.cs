using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using GooglePlayGames;

public class Muda : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameCenterPlatform.ShowDefaultAchievementCompletionBanner (true);
		Social.localUser.Authenticate(Process);
		PlayGamesPlatform.Activate();
		Social.localUser.Authenticate((bool success) => {
			if(success)
			{
				PlayerPrefs.SetInt("Logo", 1);
			}
			else
			{
				PlayerPrefs.SetInt("Logo", 0);
			}
		});
		Application.LoadLevel ("FlappyCthulhu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Process(bool sucess)
	{
		if(sucess)
		{
			Social.CreateLeaderboard();
			Social.CreateLeaderboard().id = "pontos";
			Social.ShowLeaderboardUI();
		}
		else
		{
			
		}
	}
}
