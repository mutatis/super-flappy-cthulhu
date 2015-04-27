using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class GPGDemo : MonoBehaviour
{
	#region Public_Vars
	public string leaderboard;
	#endregion
	#region Ui_Callbacks
	public Text text;
	///
	
	void Start()
	{
		PlayGamesPlatform.Activate();
		/*Social.localUser.Authenticate((bool success) => {
			// handle success or failure
		});*/
	}
	
	/// Login In Into Your Google+ Account
	/// </summary>
	public void LogIn()
	{

	}
	/// <summary>
	/// Shows All Available Leaderborad
	/// </summary>
	public void OnShowLeaderBoard()
	{
		if(PlayerPrefs.GetInt("Logo") == 1)
		{
			Social.ShowLeaderboardUI();
		}
		else
		{
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
		}
	}
	/// <summary>
	/// Adds Score To leader board
	/// </summary>
	public void OnAddScoreToLeaderBorad()
	{
		if (Social.localUser.authenticated)
		{
			Social.ReportScore(5000, leaderboard, (bool success) =>
			                   {
				if (success)
				{
					((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboard);
				}
				else
				{
					text.text = "Add Score Fail";
				}
			});
		}
	}
	/// <summary>
	/// On Logout of your Google+ Account
	/// </summary>
	public void OnLogOut()
	{
		((PlayGamesPlatform)Social.Active).SignOut();
	}
	#endregion
}