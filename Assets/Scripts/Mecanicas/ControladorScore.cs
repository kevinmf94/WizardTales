using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControladorScore : MonoBehaviour {

    private EstadoJuego estadoJuego;
    private Text scoreText;

    void Awake()
    {
        estadoJuego = GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>();
        scoreText = GetComponent<Text>();
    }

    IEnumerator sumarCamino()
    {
        while (true)
        {
            estadoJuego.getScore().incScore(2);
            yield return new WaitForSeconds(1f);
        }
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(sumarCamino());
	}

    void Update()
    {
        scoreText.text = estadoJuego.getScore().getScore().ToString();
    }

}
