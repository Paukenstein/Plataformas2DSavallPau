using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        //transform.position = target.position + offset; //la posicio de l'objecte que tingui aquest script es igual al del target
        transform.position = Vector3.Lerp(transform.position,target.position + offset, speed * Time.deltaTime);
    }
}
