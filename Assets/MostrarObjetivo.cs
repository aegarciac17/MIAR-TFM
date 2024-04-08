using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MostrarObjetivo : MonoBehaviour
{
    public GameObject objetoConTexto;
    public TextMeshProUGUI textoTiempo;
    ingredientes_selecionados ingredientes_Selecionados;
    Timer timer;

    private void Start()
    {
        ingredientes_Selecionados=FindAnyObjectByType<ingredientes_selecionados>();
        timer=FindAnyObjectByType<Timer>();
        objetoConTexto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ingredientes_Selecionados.Objetivos.Count > 0 && ingredientes_Selecionados.ingrediente_opciones<=ingredientes_Selecionados.ingredientes_nivel) 
        {
            textoTiempo.text = ingredientes_Selecionados.Objetivos[ingredientes_Selecionados.ingrediente_opciones - 1];
        }
        if (!objetoConTexto.activeSelf && timer.cuentaIniciada)
        {
            
            Debug.Log("Muestra texto");
            objetoConTexto.SetActive(true);
        }
    }
}
