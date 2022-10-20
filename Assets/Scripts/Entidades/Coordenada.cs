using UnityEngine;

public class Coordenada
{

    private float x;
    private float y;

    public Coordenada(Vector2 vector)
    {
        this.x = vector.x;
        this.y = vector.y;
    }

    public Coordenada(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2 toVector2(){
        return new Vector2(this.x, this.y);
    }

    public static Coordenada toCoordenada(Vector2 vector)
    {
        return new Coordenada(vector.x, vector.y);
    }

    public float getX()
    {
        return this.x;
    }

    public float getY()
    {
        return this.y;
    }

    public static float Distancia(Coordenada a, Coordenada b){
        return Vector2.Distance(a.toVector2(), b.toVector2());
    }

    public static Coordenada Mitad(Coordenada a, Coordenada b)
    {
        float xM = (a.getX()+b.getX()) / 2;
        float yM = (a.getY()+b.getY()) / 2;
        return new Coordenada(xM, yM);
    }

    public override string ToString()
    {
        return "Coordenada [x = " + this.x + " , y = " + this.y + "]";
    }

    public bool Equals(Coordenada obj)
    {
        if (this.x == obj.x && this.y == obj.y)
        {
            return true;
        }

        return false;
    }
}
