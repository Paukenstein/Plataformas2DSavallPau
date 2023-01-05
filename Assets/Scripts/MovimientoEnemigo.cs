using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public List<Transform> puntos;
    int puntoActual;
    public float speed;
    public Animator anim;
    void Start()
    {
        transform.position = puntos[0].position;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, puntos[puntoActual].position) < 0.1f)
        {
            puntoActual++;
            transform.localScale = new Vector3(-5, 5, 1);
            if (puntoActual >= puntos.Count)
            {
                puntoActual = 0;
                transform.localScale = new Vector3(5, 5, 1);
            }

        }
        anim.SetBool("Run", true);
        transform.position = Vector3.MoveTowards(transform.position, puntos[puntoActual].position, speed * Time.deltaTime);
        

    }
}
