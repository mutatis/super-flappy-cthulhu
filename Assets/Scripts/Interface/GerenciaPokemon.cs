using UnityEngine;
using System.Collections;

public class GerenciaPokemon : MonoBehaviour 
{	
	public StreetCthulhu[] street;
	public SpriteRenderer[] perso;
	public Sprite[] muda;
	public Transform[] posPerso;
	public Animator cthulhu;
	public AudioClip[] CthulhuSound;
	public GameObject[] menu;
	public CanoPOkemon cano;
	public MovmentMenu camera;
	
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
		yield return new WaitForSeconds(1.3f);
		cano.enabled = true;
		street[1].StopCoroutine("GO");
		yield return new WaitForSeconds(0.7f);
		cano.StopCoroutine("GO");
		for(int i = 0; i < street.Length; i++)
		{
			street[i].enabled = false;
			street[i].StopCoroutine("GO");
		}
		perso[1].sprite = muda[1];
		//posPerso[1].position = new Vector2(posPerso[1].position.x - 2, posPerso[1].position.y + 2);
		//posPerso[1].position = new Vector2(8.1f, -5.4f);
		//yield return new WaitForSeconds(0.3f);
		//posPerso[1].position = new Vector2(64.6f, 3.9f);
		//yield return new WaitForSeconds(0.1f);
		AudioSource.PlayClipAtPoint(CthulhuSound[0], new Vector3(transform.position.x, transform.position.y, transform.position.z));
		perso[0].sprite = muda[0];
		yield return new WaitForSeconds(0.1f);
		cthulhu.enabled = true;
		AudioSource.PlayClipAtPoint(CthulhuSound[1], new Vector3(transform.position.x, transform.position.y, transform.position.z));
		yield return new WaitForSeconds(1.5f);
		camera.tem = Time.deltaTime;
		camera.enabled = true;
		menu[0].SetActive(true);
	}
}