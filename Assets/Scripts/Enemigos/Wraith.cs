using UnityEngine;
using System.Collections;

public class Wraith : MonoBehaviour {

    private Vector3 posInicial;
    private Rigidbody2D body;
    private Vector2 velocidad;
	private Score score;

	void Start () {
		body = GetComponent<Rigidbody2D> ();
		posInicial = body.transform.position;
		velocidad.y = 5;
		velocidad.x = -3;
		body.velocity = velocidad;
		score = GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>().getScore();
	}
	
	void Update () {
		if (body.transform.position.y >= posInicial.y + 2) {
			velocidad.y = -4;
			body.velocity = velocidad;
		}
		if (body.transform.position.y <= posInicial.y - 2) {
			velocidad.y = 4;
			body.velocity = velocidad;
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		GameObject tocado = coll.gameObject;
		if (tocado.tag == "Proyectil") {	
			Destroy(tocado);
			Destroy(this.gameObject);
			score.incScore(15);	
		}
		if (tocado.tag == "Camino") {
			Destroy(tocado);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		GameObject tocado = coll.gameObject;
		if (tocado.tag == "Player") {
			Application.LoadLevel ("MenuJuego");
		}
		if (tocado.tag == "Camino") {
			Destroy(tocado);
		}
	}
}
