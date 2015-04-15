using UnityEngine;
using System.Collections;

public class ManagerCamera : MonoBehaviour 
{
	int cont;
	public GameObject tap;
	public GameObject pontos;

	void Awake()
	{
		//Time.timeScale = 0;
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
			pontos.SetActive(true);
			tap.SetActive (false);
			Time.timeScale = 1;
			cont ++;
		}
	}
}
