using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour 
{

	public float velX;
	public float[] velY;
	int vel_Y;
		
	// Use this for initialization
	void Start () 
	{
		vel_Y = Random.Range (0, velY.Length);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.timeScale == 1)
		{
			transform.Translate(velX, velY[vel_Y], 0);
		}
	}
}
