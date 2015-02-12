using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;

public class GameCenter : MonoBehaviour {
	
	static ILeaderboard m_Leaderboard;
	public int highScoreInt = 1000;
	
	public string leaderboardName = "leaderboard01";
	public string leaderboardID = "ponto";
	
	bool gameOver = false;
	
	// THIS MAKES SURE THE GAME CENTER INTEGRATION WILL ONLY WORK WHEN OPERATING ON AN APPLE IOS DEVICE (iPHONE, iPOD TOUCH, iPAD)
	//#if UNITY_IPHONE
	
	// Use this for initialization
	void Start () 
	{
		
		// AUTHENTICATE AND REGISTER A ProcessAuthentication CALLBACK
		// THIS CALL NEEDS OT BE MADE BEFORE WE CAN PROCEED TO OTHER CALLS IN THE Social API
		Social.localUser.Authenticate (ProcessAuthentication);
		
		// GET INSTANCE OF LEADERBOARD
		DoLeaderboard();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		#if UNITY_IPHONE
		if(gameOver == true) {
			// REPORT THE PLAYER'S SCORE WHEN THE GAME IS OVER USE A GUI BUTTON TO FLIP THE BOOLEAN FROM FALSE TO TRUE SO THIS GETS CALLED
			ReportScore(highScoreInt, leaderboardID);
		}
		#endif
		
	}
	
	// THE UI BELOW CONTAINING GUI BUTTONS IS USED TO DEMONSTRATE THE GAME CENTER INTEGRATION
	// HERE, YOU ARE ABLE TO:
	// (1) VIEW LEADERBOARDS 
	// (2) VIEW ACHIEVEMENTS
	// (3) SUBMIT HIGH SCORE TO LEADERBOARD
	// (4) REPORT ACHIEVEMENTS ACQUIRED
	// (5) RESET ACHIEVEMENTS.
	void OnGUI () 
	{	
		
		// COLUMN 1
		// SHOW LEADERBOARDS WITHIN GAME CENTER
		if(GUI.Button(new Rect(20, 20, 200, 75), "View Leaderboard")) {
			Social.ShowLeaderboardUI();
		}
		
		// SHOW ACHIEVEMENTS WITHIN GAME CENTER
		if(GUI.Button(new Rect(20, 100, 200, 75), "View Achievements")) {
			Social.ShowAchievementsUI();
		}
		
		// SET GAME OVER SWITCH
		if(GUI.Button(new Rect(20, 180, 200, 75), "Game Over Switch")) {
			// ONCE TRUE, THE UPDATE WILL HIT AND HIGH SCORE WILL BE SUBMITTED
			gameOver = true;
		}
		
		// RESET ALL ACHIEVEMENTS
		if(GUI.Button(new Rect(20, 260, 200, 75), "Reset Achievements")) {
			GameCenterPlatform.ResetAllAchievements((resetResult) => {
				Debug.Log(resetResult ? "Achievements have been Reset" : "Achievement reset failure.");
			});
		}		
	}
	
	///////////////////////////////////////////////////
	// INITAL AUTHENTICATION (MUST BE DONE FIRST)
	///////////////////////////////////////////////////
	
	// THIS FUNCTION GETS CALLED WHEN AUTHENTICATION COMPLETES
	// NOTE THAT IF THE OPERATION IS SUCCESSFUL Social.localUser WILL CONTAIN DATA FROM THE GAME CENTER SERVER
	void ProcessAuthentication (bool success) 
	{
		if (success) {
			Debug.Log ("Authenticated, checking achievements");
			
			// MAKE REQUEST TO GET LOADED ACHIEVEMENTS AND REGISTER A CALLBACK FOR PROCESSING THEM
			Social.LoadAchievements (ProcessLoadedAchievements); // ProcessLoadedAchievements FUNCTION CAN BE FOUND BELOW
			
			Social.LoadScores(leaderboardName, scores => {
				if (scores.Length > 0) {
					// SHOW THE SCORES RECEIVED
					Debug.Log ("Received " + scores.Length + " scores");
					string myScores = "Leaderboard: \n";
					foreach (IScore score in scores)
						myScores += "\t" + score.userID + " " + score.formattedValue + " " + score.date + "\n";
					Debug.Log (myScores);
				}
				else
					Debug.Log ("No scores have been loaded.");
			});
		}
		else
			Debug.Log ("Failed to authenticate with Game Center.");
	}
	
	
	// THIS FUNCTION GETS CALLED WHEN THE LoadAchievements CALL COMPLETES
	void ProcessLoadedAchievements (IAchievement[] achievements) {
		if (achievements.Length == 0)
			Debug.Log ("Error: no achievements found");
		else
			Debug.Log ("Got " + achievements.Length + " achievements");
		
		// You can also call into the functions like this
		Social.ReportProgress ("Achievement01", 100.0, result => {
			if (result)
				Debug.Log ("Successfully reported achievement progress");
			else
				Debug.Log ("Failed to report achievement");
		});
		//Social.ShowAchievementsUI();
	}
	
	///////////////////////////////////////////////////
	// GAME CENTER ACHIEVEMENT INTEGRATION
	///////////////////////////////////////////////////
	
	void ReportAchievement( string achievementId, double progress ){
		Social.ReportProgress( achievementId, progress, (result) => {
			Debug.Log( result ? string.Format("Successfully reported achievement {0}", achievementId) 
			          : string.Format("Failed to report achievement {0}", achievementId));
		});
	}
	
	#region Game Center Integration
	///////////////////////////////////////////////////
	// GAME CENTER LEADERBOARD INTEGRATION
	///////////////////////////////////////////////////
	
	
	/// <summary>
	/// Reports the score to the leaderboards.
	/// </summary>
	/// <param name="score">Score.</param>
	/// <param name="leaderboardID">Leaderboard I.</param>
	void ReportScore (long score, string leaderboardID) {
		Debug.Log ("Reporting score " + score + " on leaderboard " + leaderboardID);
		Social.ReportScore (score, leaderboardID, success => {
			Debug.Log(success ? "Reported score to leaderboard successfully" : "Failed to report score");
		});
	}
	
	/// <summary>
	/// Get the leaderboard.
	/// </summary>
	void DoLeaderboard () {
		m_Leaderboard = Social.CreateLeaderboard();
		m_Leaderboard.id = leaderboardID;  // YOUR CUSTOM LEADERBOARD NAME
		m_Leaderboard.LoadScores(result => DidLoadLeaderboard(result));
	}
	
	/// <summary>
	/// RETURNS THE NUMBER OF LEADERBOARD SCORES THAT WERE RECEIVED BY THE APP
	/// </summary>
	/// <param name="result">If set to <c>true</c> result.</param>
	void DidLoadLeaderboard (bool result) {
		Debug.Log("Received " + m_Leaderboard.scores.Length + " scores");
		foreach (IScore score in m_Leaderboard.scores) {
			Debug.Log(score);
		}
		//Social.ShowLeaderboardUI();
	}
	
	#endregion
}

//#endif