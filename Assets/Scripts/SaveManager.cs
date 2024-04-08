using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveManager
{
    
    public static void Guardar(progreso progreso) {
        string rutaDatos = Application.persistentDataPath + "/progreso.save";
        FileStream fileStream = new FileStream(rutaDatos, FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fileStream, progreso);
        fileStream.Close();
    }

    public static progreso Cargar()
    {
        string rutaDatos = Application.persistentDataPath + "/progreso.save";
        if (File.Exists(rutaDatos)) {
            FileStream fileStream = new FileStream(rutaDatos, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            progreso progreso = (progreso) formatter.Deserialize(fileStream);

            return progreso;
        }
        else {
            progreso progreso = new progreso();
            progreso.nivel_jugador = 1;
            progreso.monedas = 0;
            return progreso;
        }
    }

    public static void reiniciar() {
        progreso progreso = new progreso();
        progreso.nivel_jugador = 1;
        progreso.monedas = 0;
        Guardar(progreso);
    }
    
    [System.Serializable]
    public class progreso {
        public float nivel_jugador;
        public int monedas;    
    }
}
