using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public bool Music;

	// Use this for initialization
	void Start () {
		Music = true;

		if (GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>().musica == true) {
			GameObject.Find("BarraNull").transform.localScale = new Vector3 (0f,0f,0);

		} else {
			GameObject.Find("BarraNull").transform.localScale = new Vector3 (0.6f,0.7f,0);
		}
	}

	public void MusicOff()
	{
		if (Music)
		{
			AudioListener.pause = true;
			Music = false;
			GameObject.Find("BarraNull").transform.localScale = new Vector3 (0.6f,0.7f,0);
			GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>().musica = false;

		}
		else
		{
			AudioListener.pause = false;
			Music = true;
			GameObject.Find("BarraNull").transform.localScale = new Vector3 (0f,0f,0);
			GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>().musica = true;
		}
}
}

