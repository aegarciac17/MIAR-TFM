using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Usar_Caldero : MonoBehaviour
{
    public bool isPlayerInRange;
    public TMP_Text text;
    ElegirPocion ElegirPocion;
    ingredientes_selecionados Ingredientes_Selecionados;
    Spawn spawn;

    private void Start()
    {
        ElegirPocion = FindObjectOfType<ElegirPocion>();
        Ingredientes_Selecionados = FindObjectOfType<ingredientes_selecionados>();
        spawn = FindObjectOfType<Spawn>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E)) {


            echar_ingrediente(Ingredientes_Selecionados.ingrediente_opciones);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador")) 
        {
            isPlayerInRange = true;
            Debug.Log("Dentro del rango de uso");
            Usar();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            isPlayerInRange = false;
            Debug.Log("Fuera del rango de uso");
            Usar();
        }
    }

    private void Usar() { 
        if (isPlayerInRange)
        {
            ElegirPocion.ActivarCartel();
            text.text = "Pulsa E para añadir las opciones seleccionadas y pasar al siguiente ingrediente.";
        }
        if (!isPlayerInRange) {
            ElegirPocion.DesactivarCartel();
        }
    }

    public void echar_ingrediente(int indice_ingrediente) {
        float cantidad = 0f;
        if (indice_ingrediente == 1) {
            cantidad = Ingredientes_Selecionados.cantidad_ingrediente_1;
        }
        if (indice_ingrediente == 2)
        {
            cantidad = Ingredientes_Selecionados.cantidad_ingrediente_2;
        }
        if (indice_ingrediente == 3)
        {
            cantidad = Ingredientes_Selecionados.cantidad_ingrediente_3;
        }
        if (indice_ingrediente == 4)
        {
            cantidad = Ingredientes_Selecionados.cantidad_ingrediente_4;
        }
        if (indice_ingrediente == 5)
        {
            cantidad = Ingredientes_Selecionados.cantidad_ingrediente_5;
        }
        if (indice_ingrediente == 6)
        {
            cantidad = Ingredientes_Selecionados.cantidad_ingrediente_6;
        }
        ElegirPocion.AgregarFrase($"Has añadido {cantidad} L de {Ingredientes_Selecionados.nombres_ingrediente[indice_ingrediente-1]}");
        ElegirPocion.AgregarFrase(Ingredientes_Selecionados.error(ElegirPocion.Cantidades[Ingredientes_Selecionados.ingrediente_opciones-1],cantidad));
        ElegirPocion.indice_ingrediente_actual++;
        ElegirPocion.ActualizarTexto();
        Ingredientes_Selecionados.ingrediente_opciones++;
        spawn.destruir_opciones_ingredientes();
    }
}
