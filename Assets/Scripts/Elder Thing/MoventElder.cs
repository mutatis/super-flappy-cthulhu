using UnityEngine;
using System.Collections;

public class MoventElder : MonoBehaviour 
{
	public float tempo;
	public float velY;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Go");
		//Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.timeScale == 1)
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
		velY *= -1;
		StartCoroutine("Go");
	}
}
