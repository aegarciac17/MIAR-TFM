using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MostrarTimer : MonoBehaviour
{

    public Timer timer;
    public GameObject objetoConTexto;
    public TextMeshProUGUI textoTiempo;

    private void Start()
    {
        objetoConTexto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float tiempo = timer.ObtenerTiempoTranscurrido();
        textoTiempo.text = $"{tiempo} segundos";

        if (!objetoConTexto.activeSelf && timer.cuentaIniciada) {
            Debug.Log("Muestra texto");
            objetoConTexto.SetActive (true);
        }
    }
}
