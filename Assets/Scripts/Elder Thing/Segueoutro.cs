using UnityEngine;
using System.Collections;

public class Segueoutro : MonoBehaviour 
{

	private Vector2 direction2;
	public Transform player;
	float dist;
	public float distancia;
	bool ok;
	public float velocidade;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		dist = Vector2.Distance(transform.position, player.position);
		direction2 = (player.position - transform.position);
		direction2.Normalize();
		if(dist > 1.4f)
		transform.Translate(direction2 / 4);

		if(transform.position.x != player.position.x && player.position.x == 71)
		{
			StartCoroutine("GO");
		}
		if(ok)
		{
			transform.position = new Vector2(player.position.x, transform.position.y);
		}
	}

	IEnumerator GO()
	{
		yield return new WaitForSeconds(1);
		ok = true;
		StopCoroutine("GO");
	}
}
