using UnityEngine;
using System.Collections;

public class DibujarCaminoTouch : DibujarCamino {

	private Touch lastTouch = new Touch();
    private Vector2 nullVector = new Vector2(0, 0);

    private bool dibujar;
    private bool ataque;
	public bool muted = true;
    private float startTime;

    public GameObject proyectil;
    public float velocidadProyectil;
	public AudioClip FireBall;

    private EstadoJuego estadoJuego;


    void Awake()
    {
        estadoJuego = GameObject.Find("EstadoJuego").GetComponent<EstadoJuego>();
    }
	
	// Update is called once per frame
    void Update () {

        Vector3 posCamara = Camera.main.transform.position;
        posCamara.z = transform.position.z;
        transform.position = posCamara;

        if (Input.touchCount > 0 && dibujar)
        {

            Touch touch = Input.touches[0];

            Ray pos = Camera.main.ScreenPointToRay(touch.position);
			Vector2 destino = pos.origin;
            Vector2 lastPositionVector = new Vector2(0, 0);

            if (!lastTouch.position.Equals(nullVector))
            {
                Ray lastPosition = Camera.main.ScreenPointToRay(lastTouch.position);
                lastPositionVector = new Vector2(lastPosition.origin.x, lastPosition.origin.y);

                float distance = Vector2.Distance(lastPositionVector, destino);
                if (distance >= distanciaMaxima)
                {
                    StartCoroutine(generarRelleno(new Coordenada(lastPositionVector), new Coordenada(destino)));
                }

            }


            if(!destino.Equals(lastPositionVector)){
                Instantiate(caminoPrefab, destino, Quaternion.identity);
            }
            
            lastTouch = touch;
        }
        else
        {
            lastTouch = new Touch();
        }

	}

    void OnMouseDown()
    {
        startTime = Time.realtimeSinceStartup + 0.1f;
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
        if (!dibujar && startTime > Time.realtimeSinceStartup)
        {
            if (Input.touchCount > 0)
            {

                if (estadoJuego.getMana().getMana() >= 10f)
                {
                    estadoJuego.getMana().decMana(10f);
                    Touch touch = Input.touches[0];
                    Vector3 destino = Camera.main.ScreenToWorldPoint(touch.position);
                    Vector3 pos = GameObject.Find("Personaje").transform.position;
                    pos.x += 1f;
                    pos.z = 0;
					if (muted == false){
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
        }

        dibujar = false;
        startTime = 0;
    }

}
