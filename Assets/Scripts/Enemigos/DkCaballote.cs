using UnityEngine;
using System.Collections;

public class DkCaballote : MonoBehaviour {

	private Rigidbody2D body;
    private Vector2 velocidad;
	private Score score;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		score = GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>().getScore();
	}
	
	// Update is called once per frame
	void Update () {
		velocidad.x = -9;
		body.velocity = velocidad;
	}
	void OnTriggerEnter2D(Collider2D coll) {
		GameObject tocado = coll.gameObject;
		if (tocado.tag == "Proyectil") {
			Destroy(tocado);
			Destroy(this.gameObject);
			score.incScore(20);	
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
