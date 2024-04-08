using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class seleccionar_opcion : MonoBehaviour
{
    ingredientes_selecionados ingredientes_Selecionados;
    private SpriteRenderer spriteRenderer;
    private TextMeshProUGUI textMeshPro;
    public ElegirPocion elegirPocion;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        ingredientes_Selecionados= FindObjectOfType<ingredientes_selecionados>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            activar_opcion();
        }
    }

    public void activar_opcion()
    {
        
        // Verificar si se encontró el componente SpriteRenderer
        if (spriteRenderer != null)
        {
            if (spriteRenderer.color == Color.green)
            {
                spriteRenderer.color = Color.white;
                Debug.Log("Desactivado");
                Debug.Log(-1*ConvertirTextoADecimal(textMeshPro.text));
                ingredientes_Selecionados.incrementar_ingrediente(ingredientes_Selecionados.ingrediente_opciones, (float) (-1 * ConvertirTextoADecimal(textMeshPro.text)));
            }
            else {
                spriteRenderer.color = Color.green;
                Debug.Log("Activado");
                Debug.Log(ConvertirTextoADecimal(textMeshPro.text));
                ingredientes_Selecionados.incrementar_ingrediente(ingredientes_Selecionados.ingrediente_opciones, (float)(1 * ConvertirTextoADecimal(textMeshPro.text)));
            }
        }
    }

    public float ConvertirTextoADecimal(string texto)
    {
        string[] partes = texto.Split('/'); // Dividir la cadena en dos partes

        if (partes.Length == 2)
        {
            if (float.TryParse(partes[0], out float numerador) && float.TryParse(partes[1], out float denominador))
            {
                // Convertir el numerador y el denominador a valores decimales y realizar la división
                float valorDecimal = numerador / denominador;
                return valorDecimal;
            }
            else
            {
                Debug.LogWarning("No se pudieron convertir el numerador o el denominador a números enteros.");
            }
        }
        else if (partes.Length == 1) {
            if (int.TryParse(partes[0], out int numerador)) {
                Debug.Log(texto + " " + numerador);
                return (float) numerador;
            }
            else
            {
                Debug.LogWarning("No se pudo convertir el numerador a números enteros.");
            }
        }
        else
        {
            Debug.LogWarning("El texto no está en el formato correcto.");
        }

        // En caso de error, retornar un valor predeterminado (0)
        return 0f;
    }
}
