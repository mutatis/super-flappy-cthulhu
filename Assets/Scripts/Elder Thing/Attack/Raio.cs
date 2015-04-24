using UnityEngine;
using System.Collections;

public class Raio : MonoBehaviour {

	public float velX;
	public float limitX;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Go");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(transform.position.x > limitX)
		{
			transform.Translate(velX * Time.deltaTime, 0, 0);
		}
	}

	IEnumerator Go()
	{
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}
}
