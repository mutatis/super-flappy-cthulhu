using UnityEngine;
using System.Collections;
using Facebook.MiniJSON;

public class LogginFacebook : MonoBehaviour 
{

	void Awake()
	{
		FB.Init (Start);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void Login()
	{
		FBLogin ();
	}

	void LogCallback(FBResult response) 
	{
		Debug.Log(response.Text);
	}

	private void FBLogin() 
	{
		if(FB.IsLoggedIn)
		{

		}
		else
		{
			FB.Login("user_about_me, user_relationships, user_birthday, user_location", FBLoginCallback);
		}
	}
	
	private void FBLoginCallback(FBResult result) {
		if(FB.IsLoggedIn) {
			Debug.Log ("Logo");
		} else {
			Debug.Log ("FBLoginCallback: User canceled login");
		}
	}
}