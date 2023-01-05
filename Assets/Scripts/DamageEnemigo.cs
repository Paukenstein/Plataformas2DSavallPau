using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemigo : MonoBehaviour
{
    public int damage;
    public bool ignoreInvencible;
    public bool damaging=false;
    public string target = "Player";
    Animator anim;
    Collider2D collision;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == target)
        {
            anim.SetBool("Run", false);
            StartCoroutine(Latigo_Courutine());


            damaging = true;
            collision.GetComponent<LifeControlller>().Damage(damage, ignoreInvencible);

        }
        else{
            anim.SetBool("Damaging", false);
        }
    }
    IEnumerator Latigo_Courutine()
    {
        anim.SetBool("Damaging", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("Damaging", false);
    }
    private void Update()
    {
        

    }
}