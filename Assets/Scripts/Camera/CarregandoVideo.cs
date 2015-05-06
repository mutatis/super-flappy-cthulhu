using UnityEngine;
using System.Collections;

public class CarregandoVideo : MonoBehaviour {
	
	int x;
	string y;

	// Use this for initialization
	void Start () 
	{
		x = Random.Range(1, 10);
		y = x.ToString();
		Application.LoadLevel(y);	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
