using UnityEngine;
using System.Collections;

public class CanoDaiagonalParado : MonoBehaviour {

	float x;

	// Use this for initialization
	void Start ()
	{	
		x = Random.Range(-2, 2);
		transform.position = new Vector3(transform.position.x + x, transform.position.y + x, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
