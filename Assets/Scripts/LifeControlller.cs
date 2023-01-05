using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeControlller : MonoBehaviour
{
    public int lifes_current;
    public int lifes_max;
    public float invencible_time;
    bool invencible;
    public enum DeathMode { Teleport, ReloadScene, Destroy}
    public DeathMode death_mode;
    public Transform respawn;
    public Transform respawn2;
    public bool meta1=false;


    Rigidbody2D rb;

    void Start()
    {
        lifes_current = lifes_max;
        rb= GetComponent<Rigidbody2D>();
        
    }
    public void Damage(int damage=1, bool ignoreInvencble = false)
    {
        if (!invencible||ignoreInvencble)
        {
            lifes_current -= damage;
            StartCoroutine(Invencible_Courutine());
            StartCoroutine(Hit_Courutine());

            if (lifes_current <= 0)
            {
                Death();
            }
        }
    }
   
    IEnumerator Invencible_Courutine()
    {
        invencible = true;
        yield return new WaitForSeconds(invencible_time);

        invencible = false;
    }
    IEnumerator Hit_Courutine()
    {
        gameObject.GetComponent<MovimientoHorizontal>().anim.SetBool("hitting", true);
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<MovimientoHorizontal>().anim.SetBool("hitting", false);
    }
    public void Death()
    {
        switch (death_mode)
        {
            case DeathMode.Teleport:
                if (meta1 == false)
                {
                    transform.position = respawn.position;

                }
                else if (meta1==true)
                {
                    transform.position = respawn2.position;

                }
                lifes_current = lifes_max;
                rb.velocity = new Vector2(0, 0);
                break;
            case DeathMode.ReloadScene:
                Debug.Log("reload");
                break;
            case DeathMode.Destroy:
                Destroy(gameObject);
                    break;
            default:
                break;

        }
    }
}
