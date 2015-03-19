using UnityEngine;
using System.Collections;

public class Cano1 : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Finish")
		{
			Destroy(gameObject);
		}
	}
}
