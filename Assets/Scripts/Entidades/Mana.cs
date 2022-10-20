using UnityEngine;
using System.Collections;

public class Mana : MonoBehaviour {

    private float mana;

    IEnumerator regenerarMana()
    {
        while (true)
        {
            incMana(1f);
            yield return new WaitForSeconds(1f);
        }
    }

    void Awake()
    {
        StartCoroutine(regenerarMana());
    }

    public Mana()
    {
        this.mana = 100;
    }

    public void setMana(float mana)
    {
        this.mana = mana;
    }

    public float getMana()
    {
        return mana;
    }

    public void incMana(float mana)
    {
        if (this.mana < 100)
        {
            this.mana += mana;
        }

        if (this.mana > 100)
        {
            this.mana = 100;
        }
    }

    public void decMana(float mana)
    {
        if (this.mana > 0)
        {
            this.mana -= mana;
        }

        if (this.mana < 0)
        {
            this.mana = 0;
        }
    }
}
