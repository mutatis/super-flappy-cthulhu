using UnityEngine;
using System.Collections;

public class Retryflappy : MonoBehaviour 
{
	public void OnMouseUpAsButton()
	{
		PlayerPrefs.SetInt ("Pontos", 0);
		PlayerPrefs.SetInt ("Retry", 2);
		PlayerJump.player.morreu = false;
		PlayerJump.player.end = false;
        GameObject.FindGameObjectWithTag("Ads").GetComponent<GoogleAds>().Destroy();
        Application.LoadLevel ("FlappyCthulhu");
	}
}