using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Muda : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameCenterPlatform.ShowDefaultAchievementCompletionBanner (true);
		Social.localUser.Authenticate(Process);
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
