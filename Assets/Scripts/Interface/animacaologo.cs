using UnityEngine;
using System.Collections;

public class animacaologo : MonoBehaviour {

	public Animator anim;
	public AudioSource sweep;
	public AudioSource audios;

	public void Um()
	{
		anim.enabled = true;
	}
	public void Dois()
	{
		sweep.Play();
	}
	public void Tres()
	{
		audios.Play();
	}
}
