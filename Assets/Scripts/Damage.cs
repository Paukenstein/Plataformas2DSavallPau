using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    public int damage;
    public bool ignoreInvencible;
    public string target = "Player";
    public GameObject win;
    public Menu menu;
    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag==target&&gameObject.tag== "BannanaFIN")
        {
            Destroy(gameObject);
            menu.win = true;

        }
        else if (collision.tag==target)
        {
            collision.GetComponent<LifeControlller>().Damage(damage, ignoreInvencible);

        }

    }
   
}