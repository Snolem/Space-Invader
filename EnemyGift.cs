using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGift : MonoBehaviour
{
    public float speed = 2;


    //Gjør hastigheten til GameObject lik "speed"-variabelen.
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    //Fjærner GameObject om den kommer i kontakt med et annet GameObject med "BreakEnemyBullet"-tag.
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "BreakEnemyBullet")
        {
            Destroy(gameObject);
        }
    }
}
