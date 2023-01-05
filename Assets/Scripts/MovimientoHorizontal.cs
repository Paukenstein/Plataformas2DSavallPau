using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class MovimientoHorizontal : MonoBehaviour
{
    public float speed = 20;
    Ground_Detector ground;
    public Animator anim;
    public bool mirandoDrcha=true;
    public float horizontal;
    void Start()
    {
        ground = GetComponent<Ground_Detector>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
         horizontal = Input.GetAxis("Horizontal"); 
        transform.position = transform.position + new Vector3(horizontal*Time.deltaTime*speed, 0);
        anim.SetBool("grounded", ground.grounded);
        anim.SetBool("mooving", horizontal!=0);

        if (horizontal>0&&!mirandoDrcha)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            mirandoDrcha = true;

        }
        else if (horizontal<0&&mirandoDrcha)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 180, 0);
            mirandoDrcha = false;
        }
        if (gameObject.transform.position.y < -25)
        {
            gameObject.GetComponent<LifeControlller>().Death();
        }
    }
}
