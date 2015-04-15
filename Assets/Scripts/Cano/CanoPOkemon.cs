using UnityEngine;
using System.Collections;

public class CanoPOkemon : MonoBehaviour 
{

	public float xx;
	public float num;
	public float tempo;
	
	// Use this for initialization
	void Start ()
	{
		xx = transform.position.x;
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
		transform.position = new Vector2(xx - num, transform.position.y);
		yield return new WaitForSeconds(tempo);
		transform.position = new Vector2(xx, transform.position.y);
		StartCoroutine("GO");
	}
}
