using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float life = 5;
    public Material Lives4;
    public Material Lives3;
    public Material Lives2;
    public Material Lives1;
    public GameObject EnemyShip;

    //Henter variabler fra EnemyFleet-scriptet.
    public EnemyFleet EnemyFleet;

    public GameObject DeathEffect;
    public Transform EnemyBody;

    void OnTriggerEnter(Collider other)
    {

        // Minus en fra livene til Enemy hver gang den blir truffet av PlayerBullet.
        if(other.transform.tag == "PlayerBullet")
        {
            Debug.Log("Hit!");
            life = life -1;
        }

        //Gir GameObject et nytt material (farge) avhengig av hvor mange liv den har.
        if(life == 4)
        {
            EnemyShip.GetComponent<MeshRenderer> ().material = Lives4;
        }

        else if(life == 3)
        {
            EnemyShip.GetComponent<MeshRenderer> ().material = Lives3;
        }

        else if(life == 2)
        {
            EnemyShip.GetComponent<MeshRenderer> ().material = Lives2;
        }

        else if(life == 1)
        {
            EnemyShip.GetComponent<MeshRenderer> ().material = Lives1;
        }

        //Om life er 0 fjærnes GameObject, og en sprekke effekt blir instantiated.
        else if(life == 0)
        {
            Destroy(gameObject);
            Instantiate(DeathEffect, EnemyBody.position, EnemyBody.rotation * Quaternion.Euler (90f, 0f, 0f));
        }

    }

    //For bullets.
    public GameObject EnemyBullet;

    private float maxTime = 20;
    private float minTime = 5;

    private float time;
    private float spawnTime;

    //For gifts.
    public GameObject EnemyGift;

    private float giftMaxTime = 250;
    private float giftMinTime = 5;

    private float giftTime;
    private float giftSpawnTime;

    void Start()
    {   
        //Gjør time variabelen like minTime når man starter spillet.
        SetRandomTime();
        time = minTime;

        //Gjør giftTime variabelen like giftMinTime når man starter spillet.
        GiftSetRandomTime();
        giftTime = giftMinTime;
    }

    void FixedUpdate()
    {
        //Timer for hvor ofte bullets spawner.
        time += Time.deltaTime;
        if(time >= spawnTime)
        {
            SpawnBullet();
            SetRandomTime();
        }

        //Timer for hvor ofte gifts spawner.
        giftTime += Time.deltaTime;
        if(giftTime >= giftSpawnTime)
        {
            SpawnGift();
            GiftSetRandomTime();
        }
    }

    //Instantiater en bullet.
    void SpawnBullet()
    {
        time = 0;
        Instantiate(EnemyBullet, transform.position, EnemyBullet.transform.rotation);
    }

    //Setter spawnTime til en tilfeldig tid mellom minTime og maxTime.
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }


    //Instantiater en gift.
    void SpawnGift()
    {
        giftTime = 0;
        Instantiate(EnemyGift, transform.position, EnemyGift.transform.rotation);
    }

    //Setter giftSpawnTime til en tilfeldig tid mellom giftMinTime og giftMaxTime.
    void GiftSetRandomTime()
    {
        giftSpawnTime = Random.Range(giftMinTime, giftMaxTime);
    }

}
