using UnityEngine;
using System.Collections;

public class GerenciaOP : MonoBehaviour 
{

	public StreetCthulhu[] street;
	public SpriteRenderer[] perso;
	public Sprite[] muda;
	public Transform[] posPerso;
	public Animator cthulhu;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("GO");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	IEnumerator GO()
	{
		yield return new WaitForSeconds(2);
		for(int i = 0; i < street.Length; i++)
		{
			street[i].enabled = false;
			street[i].StopCoroutine("GO");
		}
		perso[1].sprite = muda[1];
		posPerso[1].position = new Vector2(66.8f, 3.9f);
		yield return new WaitForSeconds(0.3f);
		posPerso[1].position = new Vector2(64.6f, 3.9f);
		yield return new WaitForSeconds(0.1f);
		perso[0].sprite = muda[0];
		yield return new WaitForSeconds(0.1f);
		cthulhu.enabled = true;
	}
}
