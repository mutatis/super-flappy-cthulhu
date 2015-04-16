using UnityEngine;
using System.Collections;

public class Musica : MonoBehaviour 
{
	public AudioSource audio;
	private static Musica s_gameManager;
	public int tipo;
	bool ok;

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
		PlayerPrefs.SetInt("Musica", 0);
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
		if(PlayerPrefs.GetInt("Musica") == 1 && tipo == 0)
		{
			audio.volume -= 0.02f;
		}
		else if(PlayerPrefs.GetInt("Musica") == 1 && tipo == 1)
		{
			if(ok == false && Time.timeScale == 1)
			{
				audio.playOnAwake = true;
				audio.Play();
				ok = true;
			}
			audio.volume = 1f;
		}
	}
}
