using UnityEngine;
using System.Collections;

public class ManagerCamera : MonoBehaviour 
{
	int cont;

	void Awake()
	{
		Time.timeScale = 0;
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.timeScale == 0 && Input.GetMouseButtonDown(0) && cont == 0)
		{
			Time.timeScale = 1;
			cont ++;
		}
	}
}
