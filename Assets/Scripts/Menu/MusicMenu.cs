using UnityEngine;
using System.Collections;

public class MusicMenu : MonoBehaviour {

    private static MusicMenu instance = null;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

    }

}