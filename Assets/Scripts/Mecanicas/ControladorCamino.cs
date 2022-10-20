using UnityEngine;
using System.Collections;

public class ControladorCamino : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Camino")
            Destroy(collision.gameObject);
    }
}
