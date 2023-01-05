using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class ProyectileController : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bala;
    public Transform posicionBala;
    public float intervaloBalaCannon;
    private float nextFire;
    public bool apuntarDcha = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (gameObject.tag=="Player") {
            if (Input.GetButtonDown("Jump"))
            {

                Dispara();
                Debug.Log("Banana");
            }
        }
        if (gameObject.tag=="Cannon")
        {

            if (Time.time >= nextFire)
            {

                if (transform.position.x<posicionBala.transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0); 
                }
                nextFire = Time.time + intervaloBalaCannon;
                Dispara();

            }
        }
    }
    void Dispara()
    {
        GameObject proyectilTemp = Instantiate(bala, posicionBala.position, posicionBala.rotation);

    }
 }
