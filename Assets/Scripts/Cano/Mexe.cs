using UnityEngine;
using System.Collections;

public class Mexe : MonoBehaviour 
{

	public float tempo;
	public float velY;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Go");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.timeScale == 1)
			transform.Translate (0, velY, 0);
	}

	IEnumerator Go()
	{
		yield return new WaitForSeconds (tempo);
		velY *= -1;
		StartCoroutine("Go");
	}
}
