using UnityEngine;
using System.Collections;

public class ControladorCamara : MonoBehaviour {

    private Personaje personaje;
    private Rigidbody2D rigid;

    void Awake()
    {
        personaje = GameObject.Find("Personaje").GetComponent<Personaje>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Vector3 pos = personaje.transform.position;
        pos.y = transform.position.y;
        pos.z = -10;
        pos.x += 6f;
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector3(personaje.velocidad - 0.1f, rigid.velocity.y, -10);
    }

}
