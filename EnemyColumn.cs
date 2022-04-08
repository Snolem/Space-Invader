using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColumn : MonoBehaviour
{
    //Henter variabler fra EnemyFleet-scriptet.
    public EnemyFleet EnemyFleet;

    //Fjærner GameObject om den ikke har noen children.
    void Update()
    {
        if(transform.childCount == 0)
            {
                Destroy(gameObject);
            }
    }


    void OnTriggerEnter(Collider other)
    {
        //Får EnemyFleet objektet til å bevege seg mot høyre om GameObject treffer venstre vegg.
        if(other.transform.name == "LeftWallTurnPoint")
        {
            EnemyFleet.goingRight = true;
            EnemyFleet.gameObject.transform.position = EnemyFleet.gameObject.transform.position + new Vector3(0f, 0f, -1f);
        }

        //Får EnemyFleet objektet til å bevege seg mot venstre om GameObject treffer høyre vegg.
        if(other.transform.name == "RightWallTurnPoint")
        {
            EnemyFleet.goingRight = false;
            EnemyFleet.gameObject.transform.position = EnemyFleet.gameObject.transform.position + new Vector3(0f, 0f, -1f);
        }
    }
}
