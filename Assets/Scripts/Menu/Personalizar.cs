using UnityEngine;
using System.Collections;

public class Personalizar : MonoBehaviour {

	public GameObject Skin;
	public GameObject Estadisticas;

	public void mostrarSkins(){
		Skin.SetActive (true);
		Estadisticas.SetActive (false);
	}

	public void mostrarEstadisticas(){
		Skin.SetActive (false);
		Estadisticas.SetActive (true);
	}

}
