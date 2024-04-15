using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ControladorNivel : MonoBehaviour
{
    
    public float eleccionJugador;
    public float tiempoJugador;
    private bool modificacionRealizada = false;
    ingredientes_selecionados Ingredientes_Selecionados;
    // Start is called before the first frame update
    void Start()
    {
        Ingredientes_Selecionados=FindObjectOfType<ingredientes_selecionados>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            SaveManager.reiniciar();
            Debug.Log("Reinicio de nivel completado");
        }

        if (!modificacionRealizada && tiempoJugador != 0f)
        {

           
            SaveManager.progreso progreso = new SaveManager.progreso();
            if (Input.GetKeyDown(KeyCode.P))
            {
                // Llamar a tu función cuando se presiona la tecla 'P'
                ModificarNivel();
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                progreso.nivel_jugador= ModificarNivel();
                SaveManager.Guardar(progreso);
                Debug.Log("Progreso Guardado");
                modificacionRealizada = true;
            }

            progreso.nivel_jugador= ModificarNivel();
            progreso.monedas = Ingredientes_Selecionados.monedas;
            SaveManager.Guardar(progreso);
            Debug.Log("Progreso Guardado");
            modificacionRealizada = true;
        }
    }

    //conjunto difuso entrada eleccion ingredientes

    private float eleccionMala = 0;
    private float eleccionRegular = 0;
    private float eleccionBuena = 0;

    //conjunto difuso entrada eleccion tiempo
    private float tiempoCorto = 0;
    private float tiempoMedio = 0;
    private float tiempoLargo = 0;

    //Salida
    private float R1 = 0;
    private float R2 = 0;
    private float R3 = 0;
    private float R4 = 0;
    private float R5 = 0;
    private float R6 = 0;
    private float R7 = 0;
    private float R8 = 0;
    private float R9 = 0;

    private float DificultadAlta = 0;
    private float DificultadBaja = 0;
    private float DificultadMedia = 0;

    private float nivelResultante = 1;


    //nivel afecta a conjunto borroso 
    public float ModificarNivel()
    {
        ElegirPocion elegirPocion = FindObjectOfType<ElegirPocion>();

        // Asegurarse de que el componente ElegirPocion se haya encontrado
        if (elegirPocion != null)
        {
            float nivelActual = elegirPocion.nivel_jugador;
            float parametro_modificador_eleccion = (nivelActual - 1) * 0.04f;
            float parametro_modificador_tiempo = (nivelActual - 1) * 0.02f;


            //Fuzzificamos las entradas (El nivel deberia influir en los rangos, a mayor nivel mayor exigencia, mueve los limites 0.05)
            //0-0.40 Eleccion mala
            eleccionMala = FMembresia.GradoInversa(eleccionJugador, 0.2f, 0.5f + parametro_modificador_eleccion);
            //0.20-0.80 Eleccion regular
            eleccionRegular = FMembresia.Triangulo(eleccionJugador, 0.25f + parametro_modificador_eleccion, 0.5f + parametro_modificador_eleccion, 0.65f + parametro_modificador_eleccion);
            //0.60-1 Eleccion Buena
            eleccionBuena = FMembresia.Grado(eleccionJugador, 0.5f + parametro_modificador_eleccion, 0.65f + parametro_modificador_eleccion);
            Debug.Log(string.Format("eleccion: mala-{0}, regular-{1},buena{2}", eleccionMala, eleccionRegular, eleccionBuena));

            //0,0.75-tiempo_corto
            tiempoCorto = FMembresia.GradoInversa(tiempoJugador, 0.1f - parametro_modificador_tiempo, 0.25f - parametro_modificador_tiempo);

            //0.25-1.25 tiempo_medio
            tiempoMedio = FMembresia.Trapezoide(tiempoJugador, 0.1f - parametro_modificador_tiempo, 0.2f - parametro_modificador_tiempo, 0.25f - parametro_modificador_tiempo, 0.4f - parametro_modificador_tiempo);

            //0.75-10 tiempo largo
            tiempoLargo = FMembresia.Grado(tiempoJugador, 0.25f - parametro_modificador_tiempo, 0.35f - parametro_modificador_tiempo);

            Debug.Log(string.Format("Tiempo: corto-{0}, medio-{1},largo{2}", tiempoCorto, tiempoMedio, tiempoLargo));


            //% de dificultad
            R1 = Reglas.And(eleccionMala, tiempoLargo);
            R2 = Reglas.And(eleccionMala, tiempoMedio);
            R3 = Reglas.And(eleccionMala, tiempoCorto);
            R4 = Reglas.And(eleccionRegular, tiempoLargo);
            R5 = Reglas.And(eleccionRegular, tiempoMedio);
            R6 = Reglas.And(eleccionRegular, tiempoCorto);
            R7 = Reglas.And(eleccionBuena, tiempoLargo);
            R8 = Reglas.And(eleccionBuena, tiempoMedio);
            R9 = Reglas.And(eleccionBuena, tiempoCorto);

            DificultadBaja = Reglas.Or(R8, R9);
            DificultadMedia = Reglas.Or(Reglas.Or(Reglas.Or(R3,R5), R6),R7);
            DificultadAlta = Reglas.Or(Reglas.Or(R1,R2),R4);



            Debug.Log(string.Format("Dificultad: Baja-{0}, Media-{1},Alta{2}", DificultadBaja, DificultadMedia, DificultadAlta));
            if (Mathf.Max(DificultadBaja, DificultadMedia, DificultadAlta) == DificultadAlta)
            {
                Ingredientes_Selecionados.mensaje_controlador_nivel = $"Esta última poción no ha estado a la altura. Vuelves al nivel {nivelResultante} para repasar";
                nivelResultante = nivelActual - 1;
            }
            else if (Mathf.Max(DificultadBaja, DificultadMedia, DificultadAlta) == DificultadBaja && DificultadBaja!=DificultadMedia)
            {                
                nivelResultante = nivelActual + 1;
                Ingredientes_Selecionados.mensaje_controlador_nivel = $"¡Enhorabuena! Has subido al nivel {nivelResultante}";
            }
            else {
                nivelResultante = nivelActual;
                Ingredientes_Selecionados.mensaje_controlador_nivel = $"Sigues en nivel {nivelResultante}. ¡Un poco más y subirás de nivel!";
                
            }
           
            //Evitamos que el nivel sea menor a 1 y mayor a 5

            if (nivelResultante > 5) { nivelResultante = 5; }
            if (nivelResultante < 1) { nivelResultante = 1; }

            if (Ingredientes_Selecionados.mensaje_controlador_nivel != null && Ingredientes_Selecionados.mensaje_controlador_nivel != "")
            {
                string[] mensajes = Ingredientes_Selecionados.mensaje_controlador_nivel.ToString().Split('.');
                foreach (var frase_nivel in mensajes)
                {
                    elegirPocion.AgregarFrase(frase_nivel);
                }
                elegirPocion.AgregarFrase($"¡Mañana más y mejor!");
            }

            elegirPocion.nivel_jugador = nivelResultante;
        }
        else
        {
            Debug.LogError("No se encontró el componente ElegirPocion en la escena.");
        }

        return nivelResultante;
    }
}
