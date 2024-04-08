using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredientes_selecionados : MonoBehaviour
{
    // Start is called before the first frame update
    public float cantidad_ingrediente_1 = 0;
    public float cantidad_ingrediente_2 = 0;
    public float cantidad_ingrediente_3 = 0;
    public float cantidad_ingrediente_4 = 0;
    public float cantidad_ingrediente_5 = 0;
    public float cantidad_ingrediente_6 = 0;
    public float tiempo = 0;
    public int ingrediente_opciones = 1;
    public int ingredientes_nivel = 0;
    public int monedas = 0;
    public List<string> Objetivos= new List<string>();

    public void incrementar_ingrediente(int indice_ingrediente, float cantidad) {
        if (indice_ingrediente == 1) {
            cantidad_ingrediente_1 += cantidad;
        }
        if (indice_ingrediente == 2)
        {
            cantidad_ingrediente_2 += cantidad;
        }
        if (indice_ingrediente == 3)
        {
            cantidad_ingrediente_3 += cantidad;
        }
        if (indice_ingrediente == 4)
        {
            cantidad_ingrediente_4 += cantidad;
        }
        if (indice_ingrediente == 5)
        {
            cantidad_ingrediente_5 += cantidad;
        }
        if (indice_ingrediente == 6)
        {
            cantidad_ingrediente_6 += cantidad;
        }
    }

    public string error(float objetivo, float elegido) {
        string mensaje = "Error";
        if (objetivo - elegido == 0)
        {
            mensaje = "¡Perfecto! Sigue Así.";

        }
        else if (objetivo - elegido > 0)
        {
            mensaje = "¡Te has quedado Corto! Ten cuidado.";

        }
        else {
            mensaje = "¡Te has pasado! No necesitabas tanto";
        }
        Debug.Log($"Objetivo: {objetivo} - Elegido: {elegido}");
        return mensaje;
    }

    
}
