using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Reglas
{
    public static float And(float A, float B) {
        return Mathf.Min(A, B);
    }
    public static float Or(float A, float B)
    {
        return Mathf.Max(A, B);
    }
    public static float Negacion(float A) 
    { 
        return 1 - A;
    }

}
