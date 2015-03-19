using UnityEngine;
using System.Collections;

public class CreatedDagon : MonoBehaviour {
	
	public GameObject flappy;
	public PlayerJump pontos;
	public static CreatedDagon createdD;
	int po;
	
	void Awake()
	{
		createdD = this;
	}
	
	// Use this for initialization
	void Start () 
	{
		po = pontos.pontos + 10;
	}
	
	void Update()
	{
		if(po == pontos.pontos)
		{
			Cria();
		}
	}
	
	public void Cria()
	{
		Instantiate(flappy, new Vector3(62.142f, 13.914f, 0), Quaternion.identity);
		po += 10;
	}
	
	IEnumerator Created()
	{
		yield return new WaitForSeconds(15);
		Instantiate(flappy, new Vector3(91f, 13.914f, 0), Quaternion.identity);
		StartCoroutine("Created");
	}
}
