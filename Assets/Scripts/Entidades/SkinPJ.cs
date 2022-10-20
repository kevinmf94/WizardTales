using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkinPJ : MonoBehaviour {
	
    private string color;
    private string barba;
    private string palo;

	private Sprite[] sprites;
	// Use this for initialization
	void Awake(){
        sprites = Resources.LoadAll<Sprite>("Sprites/Mago");
        cargarConfiguracion();
        if (Application.loadedLevelName == "Personalizar")
        {
            actualizarSkin();
        }
	}

    void cargarConfiguracion()
    {
        color = PlayerPrefs.GetString("colorPersonaje");
        barba = PlayerPrefs.GetString("tipoBarba");
        palo = PlayerPrefs.GetString("tipoPalo");

        if (!PlayerPrefs.HasKey("colorPersonaje"))
        {
            color = "M";
        }
        if (!PlayerPrefs.HasKey("tipoBarba"))
        {
            barba = "B";
        }
        if (!PlayerPrefs.HasKey("tipoPalo"))
        {
            palo = "1";
        }
    }

	public void setColorMorado(){
		color = "M";
		actualizarSkin ();
	}
	public void setColorRojo(){
		color = "R";
		actualizarSkin ();
	}
	public void setColorAmarillo(){
		color = "A";
		actualizarSkin ();
	}
	public void setBarbaBlanca(){
		barba = "B";
		actualizarSkin ();
	}
	public void setBarbaMarron(){
		barba = "M";
		actualizarSkin ();
	}
	public void setSinBarba(){
		barba = "S";
		actualizarSkin ();
	}
	public void setPalo1(){
		palo = "1";
		actualizarSkin ();
	}
	public void setPalo2(){
		palo = "2";
		actualizarSkin ();
	}
	public void setPalo3(){
		palo = "3";
		actualizarSkin ();
	}
	
	public void actualizarSkin(){
		if (color == "M" && barba == "B" && palo == "1") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [1];
		}
		if (color == "M" && barba == "B" && palo == "2") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [2];
		}
		if (color == "M" && barba == "B" && palo == "3") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [3];
		}
		if (color == "M" && barba == "M" && palo == "1") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [4];
		}
		
		if (color == "M" && barba == "M" && palo == "2") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [5];
		}
		
		if (color == "M" && barba == "M" && palo == "3") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [6];
		}
		
		if (color == "M" && barba == "S" && palo == "1") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [7];
		}
		
		if (color == "M" && barba == "S" && palo == "2") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [8];
		}
		
		if (color == "M" && barba == "S" && palo == "3") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [9];
		}

		// SKIN CON TUNICA ROJA
		if (color == "R" && barba == "B" && palo == "3") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [11];
		}
		if (color == "R" && barba == "M" && palo == "1") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [12];
		}
		if (color == "R" && barba == "M" && palo == "3") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [13];
		}
		if (color == "R" && barba == "S" && palo == "1") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [14];
		}
		if (color == "R" && barba == "S" && palo == "3") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [15];
		}
		if (color == "R" && barba == "B" && palo == "1") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [16];
		}
		if (color == "R" && barba == "B" && palo == "2") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [17];
		}
		if (color == "R" && barba == "M" && palo == "2") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [18];
		}
		if (color == "R" && barba == "S" && palo == "2") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [19];
		}

		//SKIN CON TUNICA AMARILLA
		if (color == "A" && barba == "B" && palo == "1") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [20];
		}
		
		if (color == "A" && barba == "B" && palo == "2") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [21];
		}
		
		if (color == "A" && barba == "B" && palo == "3") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [22];
		}
		
		if (color == "A" && barba == "M" && palo == "1") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [23];
		}
		
		if (color == "A" && barba == "M" && palo == "2") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [24];
		}
		
		if (color == "A" && barba == "M" && palo == "3") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [25];
		}
		
		if (color == "A" && barba == "S" && palo == "1") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [26];
		}
		
		if (color == "A" && barba == "S" && palo == "2") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [27];
		}
		
		if (color == "A" && barba == "S" && palo == "3") {
			this.gameObject.GetComponent<Image> ().sprite = sprites [28];
		}

        PlayerPrefs.SetString("colorPersonaje", color);
        PlayerPrefs.SetString("tipoBarba", barba);
        PlayerPrefs.SetString("tipoPalo", palo);
        PlayerPrefs.Save();
	}

    public Sprite getSkin()
    {
        cargarConfiguracion();
        if (color == "M" && barba == "B" && palo == "1")
        {
            return sprites[1];
        }
        if (color == "M" && barba == "B" && palo == "2")
        {
            return sprites[2];
        }
        if (color == "M" && barba == "B" && palo == "3")
        {
            return sprites[3];
        }
        if (color == "M" && barba == "M" && palo == "1")
        {
            return sprites[4];
        }

        if (color == "M" && barba == "M" && palo == "2")
        {
            return sprites[5];
        }

        if (color == "M" && barba == "M" && palo == "3")
        {
            return sprites[6];
        }

        if (color == "M" && barba == "S" && palo == "1")
        {
            return sprites[7];
        }

        if (color == "M" && barba == "S" && palo == "2")
        {
            return sprites[8];
        }

        if (color == "M" && barba == "S" && palo == "3")
        {
            return sprites[9];
        }

        // SKIN CON TUNICA ROJA
        if (color == "R" && barba == "B" && palo == "3")
        {
            return sprites[11];
        }
        if (color == "R" && barba == "M" && palo == "1")
        {
            return sprites[12];
        }
        if (color == "R" && barba == "M" && palo == "3")
        {
            return sprites[13];
        }
        if (color == "R" && barba == "S" && palo == "1")
        {
            return sprites[14];
        }
        if (color == "R" && barba == "S" && palo == "3")
        {
            return sprites[15];
        }
        if (color == "R" && barba == "B" && palo == "1")
        {
            return sprites[16];
        }
        if (color == "R" && barba == "B" && palo == "2")
        {
            return sprites[17];
        }
        if (color == "R" && barba == "M" && palo == "2")
        {
            return sprites[18];
        }
        if (color == "R" && barba == "S" && palo == "2")
        {
            return sprites[19];
        }

        //SKIN CON TUNICA AMARILLA
        if (color == "A" && barba == "B" && palo == "1")
        {
            return sprites[20];
        }

        if (color == "A" && barba == "B" && palo == "2")
        {
            return sprites[21];
        }

        if (color == "A" && barba == "B" && palo == "3")
        {
            return sprites[22];
        }

        if (color == "A" && barba == "M" && palo == "1")
        {
            return sprites[23];
        }

        if (color == "A" && barba == "M" && palo == "2")
        {
            return sprites[24];
        }

        if (color == "A" && barba == "M" && palo == "3")
        {
            return sprites[25];
        }

        if (color == "A" && barba == "S" && palo == "1")
        {
            return sprites[26];
        }

        if (color == "A" && barba == "S" && palo == "2")
        {
            return sprites[27];
        }

        if (color == "A" && barba == "S" && palo == "3")
        {
            return sprites[28];
        }

        return sprites[1];
    }

}
