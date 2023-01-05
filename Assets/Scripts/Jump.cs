using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 600;
    public float force_on_air = 500;
    Ground_Detector ground;
    public int dobleSalto;
    public int maxSaltos = 2;

    void Start()
    {
        ground = GetComponent<Ground_Detector>();
        rb=GetComponent<Rigidbody2D>();        
    }

    void Update()
    {
        if (ground.grounded)
        {
            dobleSalto = maxSaltos - 1;
        }
        

        if (Input.GetKeyDown(KeyCode.UpArrow) && dobleSalto > 0)
        {
            
                dobleSalto--;
                if (ground.grounded)
                {
                    rb.AddForce(new Vector2(0, force));
                }
                else
                {
                    rb.AddForce(new Vector2(0, force_on_air));
                }
            
        }

    }
}
