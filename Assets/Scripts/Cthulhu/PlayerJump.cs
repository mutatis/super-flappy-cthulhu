using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

	public static PlayerJump player;	
	public float jumpForce;
	public float vel = -0.2f;
	[HideInInspector]
	public int pontos;
	public bool morreu;
	public bool end;
	public PolygonCollider2D box;
	public int cont;
	//public GameObject dead;
	//public GameObject image;
	//public GameObject texto;
	public AudioClip asa;
	public AudioClip death;
	public AudioClip point;
	public AudioClip afogamento;
	public Animator anim;
	int num;
	float rot = -0.5f;
	bool dagon;

	void Awake()
	{
		player = this;
	}

	// Use this for initialization
	void Start () 
	{
		pontos = PlayerPrefs.GetInt ("Pontos");
		Screen.orientation = ScreenOrientation.Portrait;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(morreu == false)
		{
			if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow))
			{
				anim.SetTrigger("Clico");
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
				AudioSource.PlayClipAtPoint(asa, new Vector3(transform.position.x, transform.position.y, transform.position.z));
				//rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
			}
			//transform.Translate(0.2f, 0, 0);
			if(rigidbody2D.velocity.y < 0)
			{
				if(transform.eulerAngles.z <= 290 || transform.eulerAngles.z >= 300)
				{
					//transform.eulerAngles = new Vector3(0, 0, 310);
					transform.Rotate(0, 0, rot);
					StartCoroutine("Roda");
				}
				else
				{
					//transform.Rotate(0, 0, -5f);
					//transform.eulerAngles = new Vector3(0, 0, 300);
				}
			}
			else if(rigidbody2D.velocity.y > 0)
			{
				rot = -0.5f;
				if(transform.eulerAngles.z <= 19)
				{
					transform.Rotate(0, 0, 0.5f);
				}
				else
				{
					transform.eulerAngles = new Vector3(0, 0, 19);
				}
			}
		}
		if(morreu && end)
		{
			transform.position = new Vector2(transform.position.x, transform.position.y - 1);
		}
	}

	IEnumerator Roda()
	{
		yield return new WaitForSeconds(0.05f);
		if(rot > -4)
		{
			rot -= 0.5f;
		}
		else
		{
			StopCoroutine("Roda");
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			vel = 0;
			AudioSource.PlayClipAtPoint(death, new Vector3(transform.position.x, transform.position.y, transform.position.z));
			morreu = true;
			anim.enabled = false;
			box.isTrigger = true;
			transform.eulerAngles = new Vector3(0, 0, -87);
			if(cont == 0)
			{
				cont = 1;
			}
			Time.timeScale = 1;
			dagon = true;
		}
		else if(collision.gameObject.tag == "Ground")
		{			
			AudioSource.PlayClipAtPoint(afogamento, new Vector3(transform.position.x, transform.position.y, transform.position.z));
			vel = 0;
			morreu = true;
			end = true;
			anim.enabled = false;
			Time.timeScale = 0;
			box.isTrigger = true;
			AudioSource.PlayClipAtPoint(death, new Vector3(transform.position.x, transform.position.y, transform.position.z));
			if(cont == 0)
			{
				cont = 1;
			}
			if(pontos > PlayerPrefs.GetInt("flappyS"))
			{
				PlayerPrefs.SetInt("flappyS", pontos);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Ponto")
		{
			AudioSource.PlayClipAtPoint(point, new Vector3(transform.position.x, transform.position.y, transform.position.z));
			if(!morreu || !end)
				pontos ++;
			Destroy(other.gameObject);
		}
		else if(other.gameObject.tag == "Enemy")
		{
			if(!dagon)
			{
				vel = 0;
				AudioSource.PlayClipAtPoint(death, new Vector3(transform.position.x, transform.position.y, transform.position.z));
				morreu = true;
				anim.enabled = false;
				box.isTrigger = true;
				transform.eulerAngles = new Vector3(0, 0, -87);
				if(cont == 0)
				{
					cont = 1;
				}
				Time.timeScale = 1;
				dagon = true;
			}
		}
		/*if(other.gameObject.tag == "Enemy")
		{
			AudioSource.PlayClipAtPoint(death, new Vector3(transform.position.x, transform.position.y, transform.position.z));
			vel = 0;
			box.isTrigger = true;
			morreu = true;
			anim.enabled = false;
			if(cont == 0)
			{
				cont = 1;
			}
			Time.timeScale = 1;
		}*/
		else if(other.gameObject.tag == "Ground")
		{
			AudioSource.PlayClipAtPoint(afogamento, new Vector3(transform.position.x, transform.position.y, transform.position.z));
			vel = 0;
			morreu = true;
			end = true;
			anim.enabled = false;
			box.isTrigger = true;
			Time.timeScale = 0;
			if(cont == 0)
			{
				cont = 1;
			}
			if(pontos > PlayerPrefs.GetInt("flappyS"))
			{
				PlayerPrefs.SetInt("flappyS", pontos);
			}
		}
	}
}
