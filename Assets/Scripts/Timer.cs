using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    private float tiempoTranscurrido=0f;
    public bool cuentaIniciada=false;
    

    // Update is called once per frame
    void Update()
    {
        if (cuentaIniciada) {
            tiempoTranscurrido += Time.deltaTime;
        }
    }

    public void IniciarCuenta() {
        Debug.Log("Iniciar Cuenta");
        cuentaIniciada = true;
    }

    public void DetenerCuenta() { 
        cuentaIniciada=false;
    }

    public void ReiniciarCuenta() { 
        tiempoTranscurrido = 0f;
        cuentaIniciada = false;
    }

    public int ObtenerTiempoTranscurrido() { 
        return (int)tiempoTranscurrido;
    }
}
