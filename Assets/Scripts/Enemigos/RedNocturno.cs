using UnityEngine;
using System.Collections;

public class RedNocturno : MonoBehaviour {

	private Vector3 posInicial;
    private Rigidbody2D body;
	public GameObject prefab;
    private Vector2 velocidad;
	private Transform trans;
    private bool atacando;
	private Score score;

	void Start () {
		trans = this.gameObject.GetComponent<Transform> ();
		body = GetComponent<Rigidbody2D> ();
        posInicial = body.transform.position;
		velocidad.y = 5;
		velocidad.x = -2;
		body.velocity = velocidad;
		score = GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>().getScore();
	}
	

	void Update () {
        if (body.transform.position.y >= posInicial.y + 0.3f)
        {
			velocidad.y = -1;
			body.velocity = velocidad;
		}
        if (body.transform.position.y <= posInicial.y - 0.3f)
        {
			velocidad.y = 1;
			body.velocity = velocidad;
		}
		if (atacando == false){
			atacando = true;
			StartCoroutine (disparar ());
	    }
	}

	private IEnumerator disparar() {

		Instantiate (prefab, new Vector3 (trans.position.x, trans.position.y-2, trans.position.z), Quaternion.identity);
		yield return new WaitForSeconds (1.5f);
		atacando = false;
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
