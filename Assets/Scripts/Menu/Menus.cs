using UnityEngine;
using System.Collections;

public class Menus : MonoBehaviour {

	public void settings()
    {
		Application.LoadLevel ("MenuJuegoSettings");
	}

	public void volverAMenu()
   {
		Application.LoadLevel ("MenuJuego");
	}

	public void personalizar()
    {
		Application.LoadLevel ("Personalizar");
	}

    public void empezarJuego()
    {
        Application.LoadLevel("Juego");
    }
}
