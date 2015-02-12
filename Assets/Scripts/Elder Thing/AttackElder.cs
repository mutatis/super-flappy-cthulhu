using UnityEngine;
using System.Collections;

public class AttackElder : MonoBehaviour 
{

	public GameObject fireball;
	public float[] tempo;
	public float time;
	int tiro;

	// Use this for initialization
	void Start () 
	{
		time = Random.Range (tempo [0], tempo [1]);
		StartCoroutine("Go");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	IEnumerator Go()
	{
		yield return new WaitForSeconds (time);
		tiro ++;
		if(tiro >= 4)
		{
			PlayerJump.player.pontos++;
			tiro = 0;
		}
		Instantiate(fireball, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
		time = Random.Range (tempo [0], tempo [1]);
		StartCoroutine("Go");
	}
}