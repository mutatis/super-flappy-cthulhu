using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageFalppy : MonoBehaviour
{
	public GameObject bronze;
	public GameObject prata;
	public GameObject ouro;
	public GameObject platina;
	public GameObject[] texto;
	bool vai;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Go");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(vai)
		{
			if(transform.localPosition.y < 18)
			{
				transform.localPosition = new Vector3 (0, transform.localPosition.y + 25, 0);
			}
			else
			{
				transform.localPosition = new Vector3(0, 20, 0);
				if(PlayerJump.player.pontos >= 10 && PlayerJump.player.pontos < 25)
				{
					bronze.SetActive(true);
				}
				else if(PlayerJump.player.pontos >= 25 && PlayerJump.player.pontos < 50)
				{
					prata.SetActive(true);
				}
				else if(PlayerJump.player.pontos >= 50 && PlayerJump.player.pontos < 100)
				{
					ouro.SetActive(true);
				}
				else if(PlayerJump.player.pontos >= 100)
				{
					platina.SetActive(true);
				}
				for(int i = 0; i < 2; i++)
				{
					texto[i].SetActive(true);
				}
			}
		}
	}

	IEnumerator Go()
	{
		float start = Time.realtimeSinceStartup;
		while (Time.realtimeSinceStartup < start + 0.75f)
		{
			yield return null;
		}
		vai = true;
	}
}
