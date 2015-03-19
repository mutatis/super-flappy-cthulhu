using UnityEngine;
using System.Collections;

public class PainelSpecial : MonoBehaviour 
{

	public Animator anim;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(PlayerJump.player.cont == 2)
		{
			anim.enabled = true;
		}
	}
}
