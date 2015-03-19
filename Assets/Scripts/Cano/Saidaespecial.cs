using UnityEngine;
using System.Collections;

public class Saidaespecial : MonoBehaviour 
{
	bool bateu;
	int som;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(som == 1)
		{
			som = 50;
		}
		if(PlayerJump.player.morreu == false && bateu)
		{
			if(som == 0)
			{
				som = 1;
			}
			PlayerJump.player.renderer.sortingOrder = 0;
			PlayerJump.player.enabled = false;
			PlayerJump.player.box.enabled = false;
			PlayerJump.player.cont = 2;
			PlayerJump.player.transform.eulerAngles = new Vector3(0, 0, -18);
			PlayerJump.player.transform.position = new Vector2(transform.position.x, PlayerJump.player.transform.position.y);
			Time.timeScale = 0.2f;
			StartCoroutine("Go");
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			bateu = true;
		}
	}
	
	IEnumerator Go()
	{
		PlayerPrefs.SetInt ("Pontos", PlayerJump.player.pontos);
		PlayerPrefs.SetInt ("Retry", 2);
		yield return new WaitForSeconds (0.3f);
		Application.LoadLevel("FlappyCthulhu");
	}
}