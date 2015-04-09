using UnityEngine;
using System.Collections;

public class Musica : MonoBehaviour 
{
	public AudioSource audio;
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(PlayerPrefs.GetInt("ONOFF") == 0)
		{
			audio.enabled = true;
		}
		else
		{
			audio.enabled = false;
		}
	}
}
