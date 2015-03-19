using UnityEngine;
using System.Collections;

public class Cano : MonoBehaviour 
{
	public BoxCollider2D box;
	BoxCollider2D box2;

	// Use this for initialization
	void Start () 
	{
		box2 = GetComponent<BoxCollider2D>();
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			box2.enabled = false;
			box.enabled = false;
		}
	}
}
