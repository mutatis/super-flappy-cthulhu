using UnityEngine;
using System.Collections;

public class CreatedFlappy : MonoBehaviour {

	//public PlayerJump player;
	public GameObject[] flappy;
	public static CreatedFlappy created;
	int po;

	void Awake()
	{
		created = this;
	}

	// Use this for initialization
	void Start () 
	{
		po = PlayerPrefs.GetInt ("Pontos");
	}

	void Update()
	{
		if(po == PlayerJump.player.pontos)
		{
			Cria();
		}
	}

	public void Cria()
	{
		if(PlayerJump.player.pontos < 15)
		{
			Instantiate(flappy[0], new Vector3(60.142f, 15.914f, 0), Quaternion.identity);
		}
		else if(PlayerJump.player.pontos < 25)
		{
			Instantiate(flappy[1], new Vector3(70.9f, 15.2f, 0), Quaternion.identity);
		}
		else if(PlayerJump.player.pontos < 35)
		{
			Instantiate(flappy[2], new Vector3(62.142f, 18.914f, 0), Quaternion.identity);
		}
		else if(PlayerJump.player.pontos < 45)
		{
			Instantiate(flappy[3], new Vector3(62.142f, 24.914f, 0), Quaternion.identity);
		}
		else if(PlayerJump.player.pontos < 50)
		{
			Instantiate(flappy[4], new Vector3(62.142f, 24.914f, 0), Quaternion.identity);
		}
		else if(PlayerJump.player.pontos < 60)
		{
			Instantiate(flappy[5], new Vector3(62.142f, 15.914f, 0), Quaternion.identity);
		}
		else if(PlayerJump.player.pontos < 70)
		{
			Instantiate(flappy[6], new Vector3(62.142f, 16.914f, 0), Quaternion.identity);
		}
		else if(PlayerJump.player.pontos < 80)
		{
			Instantiate(flappy[7], new Vector3(62.142f, 15.914f, 0), Quaternion.identity);
		}
		else if(PlayerJump.player.pontos < 90)
		{
			Instantiate(flappy[8], new Vector3(62.142f, 25.914f, 0), Quaternion.identity);
		}
		else if(PlayerJump.player.pontos < 100)
		{
			Instantiate(flappy[9], new Vector3(62.142f, 22.914f, 0), Quaternion.identity);
		}
		else if(PlayerJump.player.pontos < 110)
		{
			Instantiate(flappy[11], new Vector3(70.142f, 22.914f, 0), Quaternion.identity);
		}
		else
		{
			Instantiate(flappy[10], new Vector3(62.142f, 21f, 0), Quaternion.identity);
			Instantiate(flappy[12], new Vector3(70.142f, 22.5f, 0), Quaternion.identity);
		}
		po += 5;
	}
}
