using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoArribaAbajo : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Vector2 direccion;
    private Rigidbody2D rb2D;
    ElegirPocion ElegirPocion;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        ElegirPocion = FindObjectOfType<ElegirPocion>();
    }

    private void Update()
    {
        
        if (ElegirPocion.pocion_lista) 
        {              
            direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
    }
}
