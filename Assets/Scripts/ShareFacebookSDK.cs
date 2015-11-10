using UnityEngine;
using System.Collections;

public class ShareFacebookSDK : MonoBehaviour {
    public string linkCaption;
    public string picture;
    public string linkName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Share()
	{
		if(FB.IsLoggedIn)
		{
            linkName = PlayerPrefs.GetInt("flappyS").ToString();
            FB.Feed(
                    linkCaption: " ",
                    picture: picture,
                    linkName: "I made it all the way to " + linkName + " score on Super Flappy Cthulhu! Yes, I'm that awesome!",
                    link: "https://play.google.com/store/apps/details?id=com.DagonStudios.SuperFlappyCthulhuFinal&hl=pt_BR",
                    linkDescription: "Think you can beat my score ? Play some Super Flappy Cthulhu and test your skills. Play it now, Scrub!"
                    );
            
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
