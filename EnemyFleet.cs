using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFleet : MonoBehaviour
{
    public float speed = 1;
    public bool goingRight = false;

    public bool roundOver = false;

    public GameObject nextRound;

    
    void Update()
    {
        //Beveger GameObject til høyre om goingRight = true.
        if(goingRight == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        //Beveger GameObject til venstre om goingRight = false.
        if(goingRight == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        //Fjærner GameObject om den ikke har noen children.
        //roundOver variabelen er der for å passe på at den ikke instantiater neste runde mer enn en gang.
        if(roundOver == false && transform.childCount == 0)
        {
            roundOver = true;
            Debug.Log("Round Over. Next Round!");
            Instantiate(nextRound);
            Destroy(gameObject);
        }
    }
}
