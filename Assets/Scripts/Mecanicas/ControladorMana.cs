using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControladorMana : MonoBehaviour {

    private EstadoJuego estadoJuego;
    private Text manaHUD;

    void Awake()
    {
        estadoJuego = GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>();
        manaHUD = GameObject.Find("ManaHUD").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        manaHUD.text = "Mana: " + estadoJuego.getMana().getMana();
	}
}
