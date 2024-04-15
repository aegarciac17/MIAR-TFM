using LLMUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System;
using System.Linq;
using static ElegirPocion;
using Unity.VisualScripting;

public class ElegirPocion : MonoBehaviour
{
    ingredientes_selecionados Ingredientes_Selecionados;
    ControladorNivel ControladorNivel;
    Timer timer;
    Spawn spawn;
    public LLM llm;
    public LLMClient ingrediente1;
    public LLMClient ingrediente2;
    public LLMClient ingrediente3;
    public LLMClient ingrediente4;
    public LLMClient ingrediente5;
    public LLMClient ingrediente6;
    public TMP_Text text;
    public string[] frases;
    public int indiceFraseActual = 0;
    public int indice_ingrediente_actual = 1;
    [SerializeField] public float nivel_jugador;
    public string Instrucciones;
    public List<float> Cantidades;
    public List<string> opciones_ingrediente_1;
    public List<string> opciones_ingrediente_2;
    public List<string> opciones_ingrediente_3;
    public List<string> opciones_ingrediente_4;
    public List<string> opciones_ingrediente_5;
    public List<string> opciones_ingrediente_6;
    bool llamada_realizada;
    public bool pocion_lista;
    bool recompensa_calculada;
    public string prompt_agente_opciones;
    System.Random rnd = new System.Random();


    void HandleClientReply(string reply2)
    {
        Debug.Log(reply2);
        int loc_inicio = reply2.IndexOf("[");
        if (loc_inicio > -1)
        {
            reply2=reply2.Substring(loc_inicio+1);
            int loc_fin = reply2.IndexOf("]");
            if (loc_fin > -1)
            {
                reply2 = reply2.Substring(0, loc_fin);
                reply2=reply2.Replace("\"", "");
                if (opciones_ingrediente_1.Count==0)
                {

                    opciones_ingrediente_1 = reply2.Trim().Split(",").ToList();
                    // Generar una lista de índices aleatorios
                    var indicesAleatorios = Enumerable.Range(0, opciones_ingrediente_1.Count).OrderBy(x => rnd.Next()).ToList();

                    // Reorganizar los elementos de la lista original según los índices aleatorios
                    var listaAleatoria = indicesAleatorios.Select(i => opciones_ingrediente_1[i]).ToList();

                    // Actualizar la lista original con la nueva lista aleatoria
                    opciones_ingrediente_1.Clear();
                    opciones_ingrediente_1.AddRange(listaAleatoria);

                    if (Cantidades.Count > 1)
                    {
                        gameObject.SetActive(false);
                        ingrediente2 = gameObject.AddComponent<LLMClient>();
                        ingrediente2.prompt = prompt_agente_opciones;
                        ingrediente2.stream = false;
                        ingrediente2.seed = -1;
                        gameObject.SetActive(true);

                        ServerClientInteraction interaction3 = new ServerClientInteraction(ingrediente2);
                        interaction3.StartInteraction($"Generate options for an amount of ingredient of {Cantidades[1].ToString()} and n={nivel_jugador.ToString()}.", HandleClientReply);
                    }
                    else {
                        pocion_lista = true;
                        Debug.Log("Pocion lista");
                    }
                   

                }
                else if (opciones_ingrediente_2.Count == 0)
                {

                    opciones_ingrediente_2 = reply2.Trim().Split(",").ToList();
                    // Generar una lista de índices aleatorios
                    var indicesAleatorios = Enumerable.Range(0, opciones_ingrediente_2.Count).OrderBy(x => rnd.Next()).ToList();

                    // Reorganizar los elementos de la lista original según los índices aleatorios
                    var listaAleatoria = indicesAleatorios.Select(i => opciones_ingrediente_2[i]).ToList();

                    // Actualizar la lista original con la nueva lista aleatoria
                    opciones_ingrediente_2.Clear();
                    opciones_ingrediente_2.AddRange(listaAleatoria);


                    if (Cantidades.Count > 2)
                    {
                        gameObject.SetActive(false);
                        ingrediente3 = gameObject.AddComponent<LLMClient>();
                        ingrediente3.prompt = prompt_agente_opciones;
                        ingrediente3.stream = false;
                        ingrediente3.seed = -1;
                        gameObject.SetActive(true);

                        ServerClientInteraction interaction4 = new ServerClientInteraction(ingrediente3);
                        interaction4.StartInteraction($"Generate options for an amount of ingredient of {Cantidades[2].ToString()} and n={nivel_jugador.ToString()}.", HandleClientReply);
                    }
                    else
                    {
                        pocion_lista = true;
                        Debug.Log("Pocion lista");
                    }
                }
                else if (opciones_ingrediente_3.Count == 0)
                {

                    opciones_ingrediente_3 = reply2.Trim().Split(",").ToList();
                    // Generar una lista de índices aleatorios
                    var indicesAleatorios = Enumerable.Range(0, opciones_ingrediente_3.Count).OrderBy(x => rnd.Next()).ToList();

                    // Reorganizar los elementos de la lista original según los índices aleatorios
                    var listaAleatoria = indicesAleatorios.Select(i => opciones_ingrediente_3[i]).ToList();

                    // Actualizar la lista original con la nueva lista aleatoria
                    opciones_ingrediente_3.Clear();
                    opciones_ingrediente_3.AddRange(listaAleatoria);

                    if (Cantidades.Count > 3)
                    {
                        gameObject.SetActive(false);
                        ingrediente4 = gameObject.AddComponent<LLMClient>();
                        ingrediente4.prompt = prompt_agente_opciones;
                        ingrediente4.stream = false;
                        ingrediente4.seed = -1;
                        gameObject.SetActive(true);

                        ServerClientInteraction interaction5 = new ServerClientInteraction(ingrediente4);
                        interaction5.StartInteraction($"Generate options for an amount of ingredient of {Cantidades[3].ToString()} and n={nivel_jugador.ToString()}.", HandleClientReply);
                    }
                    else
                    {
                        pocion_lista = true;
                        Debug.Log("Pocion lista");
                    }
                }
                else if (opciones_ingrediente_4.Count == 0)
                {

                    opciones_ingrediente_4 = reply2.Trim().Split(",").ToList();
                    // Generar una lista de índices aleatorios
                    var indicesAleatorios = Enumerable.Range(0, opciones_ingrediente_4.Count).OrderBy(x => rnd.Next()).ToList();

                    // Reorganizar los elementos de la lista original según los índices aleatorios
                    var listaAleatoria = indicesAleatorios.Select(i => opciones_ingrediente_4[i]).ToList();

                    // Actualizar la lista original con la nueva lista aleatoria
                    opciones_ingrediente_4.Clear();
                    opciones_ingrediente_4.AddRange(listaAleatoria);

                    if (Cantidades.Count > 4)
                    {
                        gameObject.SetActive(false);
                        ingrediente5 = gameObject.AddComponent<LLMClient>();
                        ingrediente5.prompt = prompt_agente_opciones;
                        ingrediente5.stream = false;
                        ingrediente5.seed = -1;
                        gameObject.SetActive(true);

                        ServerClientInteraction interaction6 = new ServerClientInteraction(ingrediente5);
                        interaction6.StartInteraction($"Generate options for an amount of ingredient of {Cantidades[4].ToString()} and n={nivel_jugador.ToString()}.", HandleClientReply);
                    }
                    else
                    {
                        pocion_lista = true;
                        Debug.Log("Pocion lista");
                    }
                }
                else if (opciones_ingrediente_5.Count == 0)
                {

                    opciones_ingrediente_5 = reply2.Trim().Split(",").ToList();
                    // Generar una lista de índices aleatorios
                    var indicesAleatorios = Enumerable.Range(0, opciones_ingrediente_5.Count).OrderBy(x => rnd.Next()).ToList();

                    // Reorganizar los elementos de la lista original según los índices aleatorios
                    var listaAleatoria = indicesAleatorios.Select(i => opciones_ingrediente_5[i]).ToList();

                    // Actualizar la lista original con la nueva lista aleatoria
                    opciones_ingrediente_5.Clear();
                    opciones_ingrediente_5.AddRange(listaAleatoria);

                    if (Cantidades.Count > 5)
                    {
                        gameObject.SetActive(false);
                        ingrediente6 = gameObject.AddComponent<LLMClient>();
                        ingrediente6.prompt = prompt_agente_opciones;
                        ingrediente6.stream = false;
                        gameObject.SetActive(true);

                        ServerClientInteraction interaction5 = new ServerClientInteraction(ingrediente6);
                        interaction5.StartInteraction($"Generate options for an amount of ingredient of {Cantidades[5].ToString()} and n={nivel_jugador.ToString()}.", HandleClientReply);
                    }
                    else
                    {
                        pocion_lista = true;
                        Debug.Log("Pocion lista");
                    }
                }
                else if (opciones_ingrediente_6.Count == 0)
                {

                    opciones_ingrediente_6 = reply2.Trim().Split(",").ToList();
                    // Generar una lista de índices aleatorios
                    var indicesAleatorios = Enumerable.Range(0, opciones_ingrediente_6.Count).OrderBy(x => rnd.Next()).ToList();

                    // Reorganizar los elementos de la lista original según los índices aleatorios
                    var listaAleatoria = indicesAleatorios.Select(i => opciones_ingrediente_6[i]).ToList();

                    // Actualizar la lista original con la nueva lista aleatoria
                    opciones_ingrediente_6.Clear();
                    opciones_ingrediente_6.AddRange(listaAleatoria);
                    pocion_lista = true;
                    Debug.Log("Pocion lista");
                }
                Debug.Log("Opcion añadida");
            }
            else {
                Debug.Log(loc_inicio + " " + loc_fin);
            }
            
        }
        else {
            Debug.Log("Error al crear lista de opciones");
        }
        
    }
    
    void Start()
    {

        spawn = FindObjectOfType<Spawn>();
        timer = FindObjectOfType<Timer>();
        Ingredientes_Selecionados=FindObjectOfType<ingredientes_selecionados>();
        ControladorNivel=FindObjectOfType<ControladorNivel>();
        SaveManager.progreso progreso =SaveManager.Cargar();
        Debug.Log("Cargando progreso...");
        nivel_jugador = progreso.nivel_jugador;
        Ingredientes_Selecionados.monedas=progreso.monedas;
        Debug.Log("Nivel actualizado");
        ServerClientInteraction interaction1 = new ServerClientInteraction(llm);
        pocion_lista = false;
        recompensa_calculada = false;
        interaction1.StartInteraction("¿Qué pocion debe preparar un jugador de nivel " + nivel_jugador.ToString() + "? DEBE TENER al menos "+(nivel_jugador+1).ToString()+" ingredientes.", HandleReply);
        
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && pocion_lista)
        {
            SiguienteFrase();
        }
    }
    void HandleReply(string reply)
    {
        string mensaje = ProcesarJson(reply);
        Instrucciones = mensaje;
        frases = mensaje.Split(new string[] { "\n\r" }, StringSplitOptions.None);
        if (frases.Length > 0 && string.IsNullOrEmpty(frases[frases.Length - 1]))
        {
            frases[frases.Length - 1] = "Preparados...Listos...¡Ya!";
        }
        ActualizarTexto();
        llamada_realizada = false;
        if (Cantidades != null && Cantidades.Count > 0 && !llamada_realizada) 
        {
            
            gameObject.SetActive(false);
            ingrediente1 = gameObject.AddComponent<LLMClient>();
            ingrediente1.prompt = prompt_agente_opciones;
            ingrediente1.stream = false;
            ingrediente1.seed = -1;
            gameObject.SetActive(true);

            ServerClientInteraction interaction2 = new ServerClientInteraction(ingrediente1);
            interaction2.StartInteraction($"Generate options for an amount of ingredient of {Cantidades[0].ToString()} and n={nivel_jugador.ToString()}.", HandleClientReply);

            llamada_realizada = true;
        }
    }

    public string ProcesarJson(string reply)
    {
        try
        {
            int loc_inicio = reply.IndexOf("{");
            if (loc_inicio > -1)
            {
                reply = reply.Substring(loc_inicio);
                int loc_fin = reply.LastIndexOf("}");
                if (loc_fin > -1)
                {
                    reply = reply.Substring(0, loc_fin + 1);
                }
            }
            //comprobamos que cierre bien el json
            reply = reply.Replace("#", "");
            string reply_sin_espacios = Regex.Replace(reply, @"\s+", "");
            if (!reply_sin_espacios.Contains("]")) { reply += "]}}"; }
            if (reply_sin_espacios.Substring(reply_sin_espacios.Length - 2, 2) == "]}") { reply += "}"; }
            if (reply_sin_espacios.Substring(reply_sin_espacios.Length - 4, 4) == "]}}}") { reply =reply.Substring(0,reply.Length-1); }
            if (EsJsonValido(reply))
            {

                return FormatearRespuesta(reply);

            }
            else { return "Error json:" + reply; }
        }
        catch { return "Error json:"+reply; }


    }

    public bool EsJsonValido(string jsonString)
    {
        try
        {
            // Intentar deserializar el JSON
            JObject.Parse(jsonString);
            return true;
        }
        catch (JsonException)
        {
            // No es un JSON válido
            return false;
        }
    }

    public string FormatearRespuesta(string JsonPocion) {
        string Respuesta = "";
        Receta receta = JsonUtility.FromJson<Receta>(JsonPocion);
        Respuesta += "Vamos a preparar "+receta.pocion.nombre+", necesitaremos:\n\r";
        foreach (Ingrediente ingrediente in receta.pocion.ingredientes)
        {
            Ingredientes_Selecionados.Objetivos.Add("- "+ ingrediente.cantidad + " L de "+ ingrediente.nombre);
            Respuesta+="- "+ ingrediente.cantidad + " L de "+ ingrediente.nombre+"\n\r";
            Cantidades.Add(ingrediente.cantidad);
            Ingredientes_Selecionados.nombres_ingrediente.Add(ingrediente.nombre);
        }
        Ingredientes_Selecionados.ingredientes_nivel=Cantidades.Count();
        return Respuesta;
    }


    public void SiguienteFrase()
    {
        indiceFraseActual++;

        if (indiceFraseActual < frases.Length)
        {
            ActualizarTexto();
        }
        else
        {

            if (indice_ingrediente_actual == 1) {

                //activamos timer
                timer.IniciarCuenta();

            }
            if (indice_ingrediente_actual <= Cantidades.Count)
            {

                spawn.crear_opciones_ingrediente(indice_ingrediente_actual);
                DesactivarCartel();
            }
            else {
                if (!recompensa_calculada)
                {

                    timer.DetenerCuenta();
                    resultado();
                    Debug.Log("Nivel Finalizado");
                }
            }
        }

        
    }

    public void ActualizarTexto()
    {
        text.text = frases[indiceFraseActual];
    }

    public void DesactivarCartel()
    {
        gameObject.SetActive(false);
    }

    public void ActivarCartel() {
        gameObject.SetActive(true);
    }

    public void Crear_opciones(int indice_ingrediente) {

        if (indice_ingrediente == 1) {
            foreach (var opcion in opciones_ingrediente_1) {
                Debug.Log("prueba"); 
            }
        }
    }

    public void AgregarFrase(string nuevaFrase)
    {
        // Crear un nuevo array con una longitud mayor
        string[] nuevoArray = new string[frases.Length + 1];

        // Copiar los elementos del array original al nuevo array
        for (int i = 0; i < frases.Length; i++)
        {
            nuevoArray[i] = frases[i];
        }

        // Agregar la nueva frase al nuevo array
        nuevoArray[nuevoArray.Length - 1] = nuevaFrase;

        // Asignar el nuevo array al array original
        frases = nuevoArray;
    }

    public void resultado() {
        
        int numero_ingredientes=Cantidades.Count;
        Debug.Log (numero_ingredientes);
        int correctos = 0;
        if (numero_ingredientes >= 1 &&
            Ingredientes_Selecionados.cantidad_ingrediente_1 == Cantidades[0]) {
            Debug.Log("1 bien");
            correctos++;
        }
        if (numero_ingredientes >= 2 &&
            Ingredientes_Selecionados.cantidad_ingrediente_2 == Cantidades[1])
        {

            Debug.Log("2 bien");
            correctos++;
        }
        if (numero_ingredientes >= 3 &&
            Ingredientes_Selecionados.cantidad_ingrediente_3 == Cantidades[2])
        {
            Debug.Log("3 bien");
            correctos++;
        }
        if (numero_ingredientes >=4 &&
            Ingredientes_Selecionados.cantidad_ingrediente_4 == Cantidades[3])
        {
            Debug.Log("4 bien");
            correctos++;
        }
        if (numero_ingredientes >= 5 &&
            Ingredientes_Selecionados.cantidad_ingrediente_5 == Cantidades[4])
        {

            Debug.Log("5 bien");
            correctos++;
        }
        if (numero_ingredientes >= 6 &&
            Ingredientes_Selecionados.cantidad_ingrediente_6 == Cantidades[5])
        {

            Debug.Log("6 bien");
            correctos++;
        }
        Debug.Log($"Correctos:{correctos}");
        ControladorNivel.eleccionJugador =(float)correctos / numero_ingredientes;
        Debug.Log(ControladorNivel.eleccionJugador);
        ControladorNivel.tiempoJugador = (float)timer.ObtenerTiempoTranscurrido() / 60/numero_ingredientes;
        Debug.Log(ControladorNivel.tiempoJugador);
        string mensaje = $"Has creado una pocion valorada en {CalcularRecompensa()}";
        AgregarFrase(mensaje);
        mensaje = $"Tienes {Ingredientes_Selecionados.monedas} monedas en el banco.";
        AgregarFrase(mensaje);
        
        ActualizarTexto();

    }

    public int CalcularRecompensa() {
        recompensa_calculada = true;
        int recompensa = (int)(10 * nivel_jugador * ControladorNivel.eleccionJugador);
        Ingredientes_Selecionados.monedas += recompensa;
        return recompensa;
    }
    [System.Serializable]
    public class Ingrediente
    {
        public string nombre;
        public float cantidad;
    }

    [System.Serializable]
    public class Pocion
    {
        public string nombre;
        public Ingrediente[] ingredientes;
    }

    [System.Serializable]
    public class Receta
    {
        public Pocion pocion;
    }

}
