using UnityEngine;
using System.Collections;

public class Medalhas : MonoBehaviour 
{
	public PlayerJump pontos;
	public GameObject bronze;
	public GameObject prata;
	public GameObject ouro;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(pontos.cont == 1)
		{
			StartCoroutine("Meda");
		}
	}

	IEnumerator Meda()
	{
		yield return new WaitForSeconds(2);
		if(pontos.pontos >= 10 && pontos.pontos < 20)
		{
			bronze.SetActive(true);
		}
		else if(pontos.pontos >= 20 && pontos.pontos < 30)
		{
			prata.SetActive(true);
		}
		else if(pontos.pontos >= 30)
		{
			ouro.SetActive(true);
		}
	}
}
