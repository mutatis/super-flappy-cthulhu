using UnityEngine;
using System.Collections;

public class StreetCthulhu : MonoBehaviour
{
	public float y;
	public float num;
	public float tempo;

	// Use this for initialization
	void Start ()
	{
		y = transform.position.y;
		StartCoroutine("GO");
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	IEnumerator GO()
	{
		yield return new WaitForSeconds(tempo);
		transform.position = new Vector2(transform.position.x, y - num);
		yield return new WaitForSeconds(tempo);
		transform.position = new Vector2(transform.position.x, y);
		StartCoroutine("GO");
	}
}
