using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Muda : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Application.LoadLevel ("FlappyCthulhu");
		PlayGamesPlatform.Activate();
		Social.localUser.Authenticate((bool success) => {

		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
