using UnityEngine;
using System.Collections;

public class MoventElder : MonoBehaviour 
{
	public float tempo;
	public float velY = 6;
	bool oi;
	bool va = true;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Go");
		//Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(oi)
		{
			velY = -6;
		}
		else
		{
			velY = 6;
		}
		if(Time.timeScale == 1 && va)
		{
			transform.Translate(0, velY * Time.deltaTime, 0);
		}
		if(transform.position.x < 71)
		{
			transform.position = new Vector2(71, transform.position.y);
		}
	}

	IEnumerator Go()
	{
		yield return new WaitForSeconds (tempo);
		oi = !oi;
		StartCoroutine("Go");
	}

	IEnumerator Va()
	{
		va = false;
		yield return new WaitForSeconds(2);
		va = true;
		StopCoroutine("Va");
	}
}
