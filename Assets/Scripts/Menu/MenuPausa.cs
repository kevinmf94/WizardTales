using UnityEngine;
using System.Collections;

public class MenuPausa : MonoBehaviour {

	public GameObject menuPausa;
	public GameObject clickScreen;
	private bool paused = false;
	private EstadoJuego estadoJuego;

	void Start () {
		
		menuPausa.SetActive(false);
		Time.timeScale = 1;
	}

	void Awake()
	{
		estadoJuego = GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>();
	}

	public void pausar(){
		if (paused == false) {
			Time.timeScale = 0;
			paused = true;
			menuPausa.SetActive (true);
			clickScreen.SetActive(false);

		} 
	}

	public void reanudar(){
		if (paused) {
			Time.timeScale = 1;
			paused = false;
			menuPausa.SetActive(false);
			clickScreen.SetActive(true);
		} 
	}

	public void menu(){
		paused = false;
		Application.LoadLevel ("MenuJuego");
	}

	public void reiniciar(){
		paused = false;
		Application.LoadLevel("Juego");
		estadoJuego.getMana().setMana(100);
        estadoJuego.getScore().setScore(0);
	}
}
