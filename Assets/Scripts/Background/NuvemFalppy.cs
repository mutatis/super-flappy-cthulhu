using UnityEngine;
using System.Collections;

public class NuvemFalppy : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.timeScale == 1)
		{
			transform.Translate(-0.2f, 0, 0);
			if(transform.position.x <= 38)
			{
				transform.position = new Vector2(Random.Range(93, 140), transform.position.y);
			}
		}
	}
}
