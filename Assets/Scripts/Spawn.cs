using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public ElegirPocion elegirPocion;
    // Start is called before the first frame update
    private void Start()
    {
        elegirPocion = FindObjectOfType<ElegirPocion>();
    }
    public void InstanciarPrefabConTexto(string nuevoTexto, float x)
    {
        float x_texto = 32;
        if (x == -5) { x_texto = -190; }
        if (x == -3) { x_texto = -100; }
        if (x == -1) { x_texto = -10; }
        if (x == 1) { x_texto = 70; }
        if (x == 3) { x_texto = 160; }
        if (x == 5) { x_texto = 250; }

        // Instanciar el prefab
        GameObject instanciaPrefab = Instantiate(prefab, new Vector3(x, -3, 0), transform.rotation);

        // Obtener el componente Canvas del prefab
        Canvas canvas = instanciaPrefab.GetComponentInChildren<Canvas>();

        // Verificar si se encontró el componente Canvas
        if (canvas != null)
        {
            // Ahora, busca el componente TextMeshPro dentro del Canvas
            TextMeshProUGUI textMeshPro = canvas.GetComponentInChildren<TextMeshProUGUI>();

            // Verificar si se encontró el componente TextMeshPro
            if (textMeshPro != null)
            {
                // Hacer lo que necesites con el componente TextMeshPro
                textMeshPro.text = nuevoTexto;
                textMeshPro.transform.localPosition = new Vector3(x_texto, -125, 0);
            }
            else
            {
                Debug.LogWarning("No se encontró el componente TextMeshPro dentro del Canvas.");
            }
        }
        else
        {
            Debug.LogWarning("No se encontró el componente Canvas dentro del prefab.");
        }

    }

    public void crear_opciones_ingrediente(int indice_ingrediente) {
        Debug.Log($"Creando opciones de ingrediente {indice_ingrediente}");
        int[] posiciones = { -1, 1, -3, 3, 5, -5 };
        if (indice_ingrediente == 1) { 
            for (int i=0;i< elegirPocion.opciones_ingrediente_1.Count;i++) {
                InstanciarPrefabConTexto(elegirPocion.opciones_ingrediente_1[i], posiciones[i]);
            }
        }
        if (indice_ingrediente == 2)
        {
            for (int i = 0; i < elegirPocion.opciones_ingrediente_2.Count; i++)
            {
                InstanciarPrefabConTexto(elegirPocion.opciones_ingrediente_2[i], posiciones[i]);
            }
        }
        if (indice_ingrediente == 3)
        {
            for (int i = 0; i < elegirPocion.opciones_ingrediente_3.Count; i++)
            {
                InstanciarPrefabConTexto(elegirPocion.opciones_ingrediente_3[i], posiciones[i]);
            }
        }
        if (indice_ingrediente == 4)
        {
            for (int i = 0; i < elegirPocion.opciones_ingrediente_4.Count; i++)
            {
                InstanciarPrefabConTexto(elegirPocion.opciones_ingrediente_4[i], posiciones[i]);
            }
        }
        if (indice_ingrediente == 5)
        {
            for (int i = 0; i < elegirPocion.opciones_ingrediente_5.Count; i++)
            {
                InstanciarPrefabConTexto(elegirPocion.opciones_ingrediente_5[i], posiciones[i]);
            }
        }
        if (indice_ingrediente == 6)
        {
            for (int i = 0; i < elegirPocion.opciones_ingrediente_6.Count; i++)
            {
                InstanciarPrefabConTexto(elegirPocion.opciones_ingrediente_6[i], posiciones[i]);
            }
        }
    }

    public void destruir_opciones_ingredientes() {
        GameObject[] instancias = GameObject.FindGameObjectsWithTag(prefab.tag);
        foreach (GameObject instancia in instancias)
        {
            Destroy(instancia);
        }
    }
}
