using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoLineal : MonoBehaviour
{
    public List<Transform> puntos;
    int puntoActual;
    public float speed;
    public GameObject boton;
    public bool portalAbierto=true;
    void Start()
    {
        transform.position = puntos[0].position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, puntos[puntoActual].position) < 0.1f)
        {
           
               puntoActual++;

                if (puntoActual >= puntos.Count)
                {
                    puntoActual = 0;
                }
            

        }
        if (gameObject.tag=="PlataformaPortal")
        {
           
            if (boton.transform.localScale.y<0.5f&&portalAbierto)
            {
                
                transform.position = Vector3.MoveTowards(transform.position, puntos[puntoActual].position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, puntos[puntoActual].position) < 0.1f)
                {
                    portalAbierto = false;
                }
               
                
                

            }

        } else {
            transform.position = Vector3.MoveTowards(transform.position, puntos[puntoActual].position, speed * Time.deltaTime);
        }
        
    }
}
