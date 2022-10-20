using UnityEngine;
using System.Collections;

public class GeneradorMapa : MonoBehaviour {

	public GameObject EnemigosRespawns;
	private EstadoJuego estadoJuego;
	
	//0.6f
	private float multiplicadorAire = 0.60f;
	private float multiplicadorMedio = 0.80f;
	private float multiplicadorTerrestre = 0.90f;
    
    //Enemigos&Escenas
    private GameObject[] enemigosgo;
    private GameObject[] escenas;
	
	void Awake()
	{
		estadoJuego = GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>();
        enemigosgo = Resources.LoadAll<GameObject>("Prefabs/Enemigos");
        escenas = Resources.LoadAll<GameObject>("Prefabs/Escenas");
	}

    private ArrayList obtenerRespawns(Transform enemigos, string posicion, string tipo)
	{
		ArrayList gameObjectsAire = new ArrayList();
		if(enemigos.Find(posicion) != null){
			
			Transform aire = enemigos.Find(posicion);
			for (int i = 0; i < aire.transform.childCount; i++)
			{
				Transform respawn = aire.transform.GetChild(i);
				if (respawn.tag == tipo)
				{
					gameObjectsAire.Add(respawn);
				}
			}
			
		}
		
		return gameObjectsAire;
	}
	
	private Transform obtenerEnemigo(GameObject escena)
	{
		Transform enemigos = null;
		enemigos = escena.transform.Find("Enemigos");
		return enemigos;
	}
	
	private IEnumerator generarEnemigos(GameObject escena)
	{
		Transform enemigos = obtenerEnemigo(escena);
		if (enemigos != null)
		{
            ArrayList respawnAire = obtenerRespawns(enemigos, "Aire", "EnemigoAire");
            ArrayList respawnMedio = obtenerRespawns(enemigos, "Medio", "EnemigoMedio");
            ArrayList respawnTierra = obtenerRespawns(enemigos, "Tierra", "EnemigoTerrestre");
			StartCoroutine(generarEnemigosAire(respawnAire));
			StartCoroutine(generarEnemigosMedio(respawnMedio));
			StartCoroutine(generarEnemigosTierra(respawnTierra));
		}
		
		yield return null;
	}
	
	private IEnumerator instanciarEnemigos(ArrayList respawns, ArrayList enemigosFacil, 
	                               ArrayList enemigosMedio, ArrayList enemigosDificil, float multiplicador)
	{
		foreach (Transform pos in respawns)
		{
			float rand = Random.Range(0f, 100f);
			if (rand < (multiplicador * estadoJuego.getScore().getScore()))
			{
				int dificultad = Random.Range(0, 100);
				GameObject gameObject = null;
				//Facil
				if (dificultad <= 50 && enemigosFacil.Count > 0)
				{
					int enemigoRandom = Random.Range(0, enemigosFacil.Count);
					gameObject = enemigosFacil[enemigoRandom] as GameObject;
				}
				
				//Medio
				if (dificultad > 50 && dificultad <= 80 && enemigosMedio.Count > 0)
				{
					int enemigoRandom = Random.Range(0, enemigosMedio.Count);
					gameObject = enemigosMedio[enemigoRandom] as GameObject;
				}
				
				//Dificil
				if (dificultad > 80 && enemigosDificil.Count > 0)
				{
					int enemigoRandom = Random.Range(0, enemigosDificil.Count);
					gameObject = enemigosDificil[enemigoRandom] as GameObject;
				}
				
				if(gameObject != null)
					Instantiate(gameObject, pos.position, Quaternion.identity);
			}
		}
		yield return null;
	}
	
	private ArrayList obtenerPrefabEnemigos(string tipo)
	{
		ArrayList enemigos = new ArrayList();
		foreach (GameObject obj in enemigosgo)
		{
			if (obj.tag.Contains(tipo))
			{
				enemigos.Add(obj);
			}
		}
		return enemigos;
	}
	
	private IEnumerator generarEnemigosTierra(ArrayList respawns)
	{
		ArrayList enemigosFacil = obtenerPrefabEnemigos("EnemigoTerrestreFacil");
		ArrayList enemigosMedio = obtenerPrefabEnemigos("EnemigoTerrestreMedio");
		ArrayList enemigosDificil = obtenerPrefabEnemigos("EnemigoTerrestreDificil");
		StartCoroutine(instanciarEnemigos(respawns, enemigosFacil, 
		                                  enemigosMedio, enemigosDificil, multiplicadorTerrestre));
		yield return null;
	}

    private IEnumerator generarEnemigosAire(ArrayList respawns)
	{
		ArrayList enemigosFacil = obtenerPrefabEnemigos("EnemigoAireFacil");
		ArrayList enemigosMedio = obtenerPrefabEnemigos("EnemigoAireMedio");
		ArrayList enemigosDificil = obtenerPrefabEnemigos("EnemigoAireDificil");
		StartCoroutine(instanciarEnemigos(respawns, enemigosFacil,
		                                  enemigosMedio, enemigosDificil, multiplicadorAire));
		yield return null;
	}

    private IEnumerator generarEnemigosMedio(ArrayList respawns)
	{
		ArrayList enemigosFacil = obtenerPrefabEnemigos("EnemigoMedioFacil");
		ArrayList enemigosMedio = obtenerPrefabEnemigos("EnemigoMedioMedio");
		ArrayList enemigosDificil = obtenerPrefabEnemigos("EnemigoMedioDificil");
		StartCoroutine(instanciarEnemigos(respawns, enemigosFacil,
		                                  enemigosMedio, enemigosDificil, multiplicadorMedio));
		yield return null;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			int rand = Random.Range(0, escenas.Length);
			Vector3 pos = transform.position + new Vector3(23.4f, 0, 10);
			pos.y=-5f;
			Object nextEscena = Instantiate(escenas[rand], pos, Quaternion.identity);
			GameObject escena = (GameObject) nextEscena;
			StartCoroutine(generarEnemigos(escena));
		}
	}   
}
