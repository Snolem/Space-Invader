using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5;

    void Update()
    {
        //Gjør hastigheten til GameObject lik "speed"-variabelen.
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        //Gjør at speed ikke blir mer enn 10.
        if (speed >= 10)
        {
            speed = 10;
        }
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
