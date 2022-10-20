using UnityEngine;
using System.Collections;

public class Personaje : MonoBehaviour {

	public float velocidad;
    public float velocidadSalto;
	private Rigidbody2D body;
    private bool canSalto = true;
    private EstadoJuego estadoJuego;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        estadoJuego = GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = estadoJuego.getSkinPJ().getSkin();
    }

    void Start()
    {
        estadoJuego.getMana().setMana(100);
		estadoJuego.getScore().setScore(0);
    }

	void Update () 
    {
        body.velocity = new Vector3(velocidad, body.velocity.y, 0);
	}

	void OnMouseDown()
    {
        if (canSalto)
        {
            body.velocity = new Vector2(body.velocity.x, velocidadSalto);
            canSalto = false;
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemigo" || collision.gameObject.name != "LimitePersonaje" )
        {
            canSalto = true;    
        }

        if(collision.gameObject.name == "LimitePersonaje")
        {
            body.velocity = new Vector3(0, body.velocity.y, 0);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "ZonaCamara")
        {
            Application.LoadLevel(0);
        }
    }
}
