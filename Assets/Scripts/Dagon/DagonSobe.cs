﻿using UnityEngine;
using System.Collections;

public class DagonSobe : MonoBehaviour 
{

	public float vel;
	public Transform y;
	public int tipo;
	bool va;
	public AudioClip audio;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(va && transform.position.y > y.position.y && tipo == 1)
		{
			transform.Translate(0, vel, 0);
		}	
		if(va && transform.position.y < y.position.y && tipo == 0)
		{
			transform.Translate(0, vel, 0);
		}	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Apareca")
		{
			AudioSource.PlayClipAtPoint(audio, new Vector3(transform.position.x, transform.position.y, transform.position.z));
			va = true;
		}
	}
}