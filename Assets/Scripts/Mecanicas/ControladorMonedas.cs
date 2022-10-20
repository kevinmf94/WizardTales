using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControladorMonedas : MonoBehaviour {

    private EstadoJuego estadoJuego;
    private Text monedasHUD;

    void Awake()
    {
        estadoJuego = GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>();
        monedasHUD = GameObject.Find("MonedasHUD").GetComponent<Text>();
    }

	// Use this for initialization
	void Start () {
        monedasHUD.text = estadoJuego.getMonedas().getMonedas().ToString();
	}

}
