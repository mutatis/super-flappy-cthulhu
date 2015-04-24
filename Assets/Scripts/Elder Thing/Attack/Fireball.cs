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
		transform.eulerAngles = new Vector3(0, 0, velY[vel_Y]);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.timeScale == 1)
		{
			transform.Translate(velX * Time.deltaTime, 0, 0);
		}
	}
}
