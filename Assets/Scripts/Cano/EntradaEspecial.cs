using UnityEngine;
using System.Collections;

public class EntradaEspecial : MonoBehaviour 
{

	bool bateu;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(bateu && PlayerJump.player.pontos == 2)
		{
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
			Debug.Log("Porra");
			bateu = true;
		}
	}

	IEnumerator Go()
	{
		yield return new WaitForSeconds (0.3f);
		Application.LoadLevel("DagonSpecial");
	}
}
