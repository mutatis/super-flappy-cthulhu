using UnityEngine;
using System.Collections;

public class Musica : MonoBehaviour 
{
	public AudioSource audio;
	private static Musica s_gameManager;

	public static Musica gameManager
	{
		get
		{
			if (s_gameManager == null)
			{
				s_gameManager = FindObjectOfType(typeof(Musica)) as Musica;
				
				if (s_gameManager == null)
				{
					GameObject obj = new GameObject("Musica");
					s_gameManager = obj.AddComponent(typeof(Musica)) as Musica;
				}
			}
			
			return s_gameManager;
		}
	}

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () 
	{
		PlayerPrefs.SetInt ("Retry", 0);	
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
