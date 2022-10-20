using UnityEngine;
using System.Collections;

public class EstadoJuego : MonoBehaviour {

    private Mana mana;
    private SkinPJ skinPJ;
    private static EstadoJuego instance = null;
    private Monedas monedas;
    private Score score;
	public bool musica = true;

    void Awake()
    {
        mana = gameObject.AddComponent<Mana>();
        skinPJ = gameObject.AddComponent<SkinPJ>();
        monedas = gameObject.AddComponent<Monedas>();
        score = gameObject.AddComponent<Score>();

        if (PlayerPrefs.HasKey("monedas"))
        {
            monedas.setMonedas(PlayerPrefs.GetInt("monedas"));
        }

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

    public Mana getMana()
    {
        return mana;
    }

    public void setMana(Mana mana)
    {
        this.mana = mana;
    }

    public SkinPJ getSkinPJ()
    {
        return skinPJ;
    }

    public void setSkinPJ(SkinPJ skinPJ)
    {
        this.skinPJ = skinPJ;
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }

    public Monedas getMonedas()
    {
        return monedas;
    }

    public void setMonedas(Monedas monedas)
    {
        this.monedas = monedas;
    }

    public Score getScore()
    {
        return score;
    }

    public void setScore(Score score)
    {
        this.score = score;
    }
}
