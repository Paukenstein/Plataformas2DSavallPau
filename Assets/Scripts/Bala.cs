using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.right*speed *Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag=="Bananna") {
            if (collision.tag != "Enemigo" && collision.tag != "Player")
            {

                Destroy(gameObject);
            } else if (collision.tag == "Enemigo")
            {
                collision.gameObject.GetComponent<LifeControlller>().Death();
                Destroy(gameObject);
            }
        }
        if (gameObject.tag=="CannonBall")
        {
            if (collision.tag == "Player")
            {
                collision.gameObject.GetComponent<LifeControlller>().Damage(1, true);
                Destroy(gameObject);
            }
            else if(collision.tag!="Player"&&collision.tag!="Cannon")
            {
                Destroy(gameObject);
            }
        }
    }
}
