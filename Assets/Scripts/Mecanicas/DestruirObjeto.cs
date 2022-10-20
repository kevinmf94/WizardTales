using UnityEngine;
using System.Collections;

public class DestruirObjeto : MonoBehaviour {

	public float destroyTime;

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }

	void Start () {
        StartCoroutine(destroy());
	}

}
