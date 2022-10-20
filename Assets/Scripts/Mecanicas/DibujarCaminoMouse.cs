using UnityEngine;
using System.Collections;

public class DibujarCaminoMouse : DibujarCamino {

	private Coordenada lastPoint = new Coordenada(0, 0);
    private Coordenada nullVector = new Coordenada(0, 0);

    private float startTime;
    private bool dibujar;
	public bool muted = true;

    public GameObject proyectil;
    public float velocidadProyectil;
	public AudioClip FireBall;

    private EstadoJuego estadoJuego;

    void Awake()
    {
        estadoJuego = GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>();
    }

	// Update is called once per frame
    void Update()
    {

        Vector3 posCamara = Camera.main.transform.position;
        posCamara.z = transform.position.z;
        transform.position = posCamara;

		if(dibujar && Input.GetMouseButton(0)) {

            Coordenada mouse = new Coordenada(Input.mousePosition);

            Ray pos = Camera.main.ScreenPointToRay(mouse.toVector2());
			Coordenada destino = Coordenada.toCoordenada(pos.origin);
            Coordenada lastPositionVector = new Coordenada(0, 0);

            if (!lastPoint.Equals(nullVector))
            {
                Ray lastPosition = Camera.main.ScreenPointToRay(lastPoint.toVector2());
                lastPositionVector = new Coordenada(lastPosition.origin.x, lastPosition.origin.y);

                float distance = Coordenada.Distancia(lastPositionVector, destino);
                if (distance >= distanciaMaxima)
                {
                    StartCoroutine(generarRelleno(lastPositionVector, destino));
                }
            }

            Instantiate(caminoPrefab, destino.toVector2(), Quaternion.identity);

            lastPoint = mouse;
        }
        else
        {
            lastPoint = new Coordenada(0, 0);
        }


	}

    void OnMouseDown()
    {
        startTime = Time.realtimeSinceStartup + 0.09f;
    }

    void OnMouseDrag()
    {
        if (startTime < Time.realtimeSinceStartup)
        {
            dibujar = true;
        }
    }

    void OnMouseUp()
    {
        if (!dibujar && startTime >= Time.realtimeSinceStartup)
        {
            if (estadoJuego.getMana().getMana() >= 10f)
            {

				GetComponent<AudioSource>().PlayOneShot(FireBall);

                estadoJuego.getMana().decMana(10f);
                Vector3 destino = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 pos = GameObject.Find("Personaje").transform.position;
                pos.x += 1f;
                pos.z = 0;
                if (muted == false)
                {
                    GetComponent<AudioSource>().PlayOneShot(FireBall);
                }
                Object obj = Instantiate(proyectil, pos, Quaternion.identity);
                GameObject obj2 = (GameObject)obj;
                float deltaX = destino.x - pos.x;
                float deltaY = destino.y - pos.y;
                float normDeltaX = deltaX / Mathf.Sqrt(Mathf.Pow(deltaX, 2) + Mathf.Pow(deltaY, 2));
                float normDeltaY = deltaY / Mathf.Sqrt(Mathf.Pow(deltaX, 2) + Mathf.Pow(deltaY, 2));
                obj2.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(normDeltaX * velocidadProyectil, normDeltaY * velocidadProyectil);
            }
        }

        dibujar = false;
        startTime = 0;
    }


}
