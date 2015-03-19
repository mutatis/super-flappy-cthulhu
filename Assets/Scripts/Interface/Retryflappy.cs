using UnityEngine;
using System.Collections;

public class Retryflappy : MonoBehaviour 
{
	public void OnMouseUpAsButton()
	{
		PlayerPrefs.SetInt ("Pontos", 0);
		PlayerPrefs.SetInt ("Retry", 2);
		Application.LoadLevel ("FlappyCthulhu");
	}
}
