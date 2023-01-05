using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Detector : MonoBehaviour
{
    public bool grounded;
    public float lenght = 1;
    public LayerMask mask;
    public List<Vector3> originalPoints;
    bool presionBoton=false;
   void Start()
    {
        
    }

    void Update()
    {
        grounded = false;
        for (int i =0; i<originalPoints.Count; i++)
        {
            Debug.DrawRay(transform.position + originalPoints[i], Vector3.down*lenght, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position + originalPoints[i], Vector3.down, lenght, mask);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "PlataformaMovil")
                {
                    transform.parent = hit.transform;
                }
                Debug.DrawRay(transform.position + originalPoints[i], Vector3.down * hit.distance, Color.green);
                grounded = true;
                if (hit.collider.tag=="Boton"&&!presionBoton)
                {
                    Debug.Log(hit.collider.tag);
                    hit.collider.transform.localScale= new Vector3(hit.collider.transform.localScale.x,0.4f,hit.collider.transform.localScale.z);
                    presionBoton = true;
                }
                if (hit.collider.tag=="Meta1")
                {
                    gameObject.GetComponent<LifeControlller>().meta1 = true;
                }
            }

        }
        if (!grounded)
        {
            transform.parent = null;
        }

    }
}
