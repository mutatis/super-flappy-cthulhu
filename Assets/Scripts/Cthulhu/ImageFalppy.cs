using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageFalppy : MonoBehaviour
{
	public GameObject[] texto;
	public GameObject[] idolos;
	bool vai;
	public int limit;
	int num = 25;

	// Use this for initialization
	void Start () 
	{
#if UNITY_IOS
		num *= 2;
#endif
		StartCoroutine("Go");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3(transform.position.x, transform.position.y, 200);
		if(vai)
		{
			if(transform.localPosition.y < limit - 2)
			{
				transform.localPosition = new Vector3 (0, transform.localPosition.y + num, 0);
			}
			else
			{
				transform.localPosition = new Vector3(0, limit, 0);
				if(PlayerJump.player.pontos >= 0 && PlayerJump.player.pontos < 10)
				{
					idolos[0].SetActive(true);
				}
				else if(PlayerJump.player.pontos >= 10 && PlayerJump.player.pontos < 25)
				{
					idolos[1].SetActive(true);
				}
				else if(PlayerJump.player.pontos >= 25 && PlayerJump.player.pontos < 50)
				{
					idolos[2].SetActive(true);
				}
				else if(PlayerJump.player.pontos >= 50 && PlayerJump.player.pontos < 70)
				{
					idolos[3].SetActive(true);
				}
				else if(PlayerJump.player.pontos >= 70 && PlayerJump.player.pontos < 110)
				{
					idolos[4].SetActive(true);
				}
				else if(PlayerJump.player.pontos >= 110)
				{
					idolos[5].SetActive(true);
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
