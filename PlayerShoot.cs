using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePoint;


    //Instantiater en Bullet når man trykker space.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
        }
    }
}
