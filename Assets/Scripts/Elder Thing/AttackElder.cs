using UnityEngine;
using System.Collections;

public class AttackElder : MonoBehaviour 
{
	public GameObject raio;
	public GameObject fireball;
	public float[] tempo;
	public float time;
	public Animator[] anim;
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
		if(tiro == 4)
		{
			for(int i = 0; i < anim.Length; i++)
			{
				anim[i].SetTrigger("Raio");
			}
			yield return new WaitForSeconds(3);
			tiro = 0;
		}
		else if(tiro <= 4)
		{
			for(int i = 0; i < anim.Length; i++)
			{
				anim[i].SetTrigger("Fireball");
			}
		}
		time = Random.Range (tempo [0], tempo [1]);
		StartCoroutine("Go");
	}

	public void Raio()
	{
		Instantiate(raio, new Vector3(81, transform.position.y, transform.position.z), Quaternion.identity);
	}

	public void Firaball()
	{
		Instantiate(fireball, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
	}
}