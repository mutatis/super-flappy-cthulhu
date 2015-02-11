using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageFalppy : MonoBehaviour
{
	public PlayerJump pontos;
	public GameObject bronze;
	public GameObject prata;
	public GameObject ouro;
	public GameObject platina;
	public GameObject[] texto;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.localPosition.y < 20)
		{
			transform.localPosition = new Vector3 (0, transform.localPosition.y + 25, 0);
		}
		else
		{
			transform.localPosition = new Vector3(0, 20, 0);
			if(pontos.pontos >= 10 && pontos.pontos < 25)
			{
				bronze.SetActive(true);
			}
			else if(pontos.pontos >= 25 && pontos.pontos < 50)
			{
				prata.SetActive(true);
			}
			else if(pontos.pontos >= 50 && pontos.pontos < 100)
			{
				ouro.SetActive(true);
			}
			else if(pontos.pontos >= 100)
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
