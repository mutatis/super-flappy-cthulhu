using UnityEngine;
using System.Collections;

public class Raio : MonoBehaviour {

	public float velX;
	public float limitX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(transform.position.x > limitX)
		{
			transform.Translate(velX, 0, 0);
		}
	}
}
