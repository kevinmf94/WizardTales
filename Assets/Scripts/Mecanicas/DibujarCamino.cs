using UnityEngine;
using System.Collections;

public class DibujarCamino : MonoBehaviour {

	private GameObject player;
	public GameObject caminoPrefab;
    public float distanciaMaxima = 0.254f;

    protected IEnumerator generarRelleno(Coordenada a, Coordenada b)
    {

        if (Coordenada.Distancia(a, b) > distanciaMaxima)
        {
            Coordenada mitad = Coordenada.Mitad(a, b);
            Instantiate(caminoPrefab, mitad.toVector2(), Quaternion.identity);

            if (Coordenada.Distancia(a, mitad) > distanciaMaxima)
            {
                StartCoroutine(generarRelleno(a, mitad));
            }

            if (Coordenada.Distancia(mitad, b) > distanciaMaxima)
            {
                StartCoroutine(generarRelleno(mitad, b));
            }
            
        }

        yield return new WaitForSeconds(0.0f);
    }

}
