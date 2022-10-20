using UnityEngine;
using System.Collections;

public class Monedas : MonoBehaviour {

	private int monedas;

    public Monedas(int monedas)
    {
        this.monedas = monedas;
    }

    public void setMonedas(int monedas)
    {
        this.monedas = monedas;
    }

    public int getMonedas()
    {
        return monedas;
    }

    public void incMonedas(int monedas)
    {
        this.monedas += monedas;
    }

    public void decMonedas(int monedas)
    {
        this.monedas -= monedas;
    }
}
