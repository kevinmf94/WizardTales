using UnityEngine;
using System.Collections;

public class ProyectilEnemigo : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		GameObject tocado = coll.gameObject;

		if (tocado.tag == "Player") {
			Application.LoadLevel ("MenuJuego");
		}
	}
}
