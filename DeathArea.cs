using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathArea : MonoBehaviour
{
    //Gjør livene til 0 (nedelag) om en enemy kommer i kontakt med DeathArea området.
    public PlayerHealth PlayerHeatlh;

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "BreakPlayerBullet")
        {
            PlayerHealth.life = 0;
        }
    }
    
}
