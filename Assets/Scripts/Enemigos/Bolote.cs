using UnityEngine;
using System.Collections;

public class Bolote : MonoBehaviour {

	private Score score;

	void Start () {
		score = GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>().getScore();
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
		}if (tocado.tag == "Player") {
			Application.LoadLevel ("MenuJuego");
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		GameObject tocado = coll.gameObject;

		if (tocado.tag == "Camino") {
			Destroy(tocado);
		}
	}

}
