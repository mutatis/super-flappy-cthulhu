using UnityEngine;
using System.Collections;

public class CreatedFlappy : MonoBehaviour {

	public GameObject flappy;
	public PlayerJump pontos;
	int po;

	// Use this for initialization
	void Start () 
	{
		po = pontos.pontos + 10;
	}

	void Update()
	{
		if(po == pontos.pontos)
		{
			Instantiate(flappy, new Vector3(62.142f, 13.914f, 0), Quaternion.identity);
			po += 10;
		}
	}
	
	IEnumerator Created()
	{
		yield return new WaitForSeconds(15);
		Instantiate(flappy, new Vector3(62.142f, 13.914f, 0), Quaternion.identity);
		StartCoroutine("Created");
	}
}
