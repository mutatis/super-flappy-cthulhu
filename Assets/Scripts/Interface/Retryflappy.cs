using UnityEngine;
using System.Collections;

public class Retryflappy : MonoBehaviour {

	public void OnMouseUpAsButton()
	{
		StartCoroutine("Va");
		Time.timeScale = 1;
	}
	
	IEnumerator Va ()
	{
		Time.timeScale = 1;
		AsyncOperation async = Application.LoadLevelAsync("FlappyCthulhu");
		yield return async;
	}
}
