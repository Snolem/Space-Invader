using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;

    //Beveger bullet oppover med hastigheten til speed variabelen.
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    //Fjærner GameObject når den kommer i kontakt med et annet GameObject med en "BreakPlayerBullet"-tag.
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "BreakPlayerBullet")
        {
            Destroy(gameObject);
        }
    }
}
