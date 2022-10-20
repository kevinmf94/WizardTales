using UnityEngine;
using System.Collections;

public class EffectController : MonoBehaviour {

	private AudioSource effects;
	private static bool muteNow;

	// Use this for initialization
	void Start () {
		effects = GetComponent<AudioSource>();
		muteNow = false;
	}
	
	// Update is called once per frame
	public void Botonaso () {
		if(gameObject.GetComponent<DibujarCaminoMouse>().muted) {
			gameObject.GetComponent<DibujarCaminoMouse>().muted = false;
			}else{
			gameObject.GetComponent<DibujarCaminoMouse>().muted = true;
		}
	}
}
