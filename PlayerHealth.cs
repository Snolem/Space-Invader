using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static float life = 3;
    public GameObject DeathEffect;
    public Transform Player;

    public GameObject HealthBlock;
    public GameObject MinusHealthParticles;
    public GameObject HealthPoint;

    //Bool for å vite om et liv alerede eksisterer.
    private bool HealthBlock1Exists = true;
    private bool HealthBlock2Exists = true;
    private bool HealthBlock3Exists = false;
    private bool HealthBlock4Exists = false;
    private bool HealthBlock5Exists = false;
    private bool HealthBlock6Exists = false;
    private bool HealthBlock7Exists = false;
    private bool HealthBlock8Exists = false;
    private bool HealthBlock9Exists = false;
    private bool HealthBlock10Exists = false;

    //Plasseringen til livene.
    public Transform HealthSlot1;
    public Transform HealthSlot2;
    public Transform HealthSlot3;
    public Transform HealthSlot4;
    public Transform HealthSlot5;
    public Transform HealthSlot6;
    public Transform HealthSlot7;
    public Transform HealthSlot8;
    public Transform HealthSlot9;
    public Transform HealthSlot10;

    public GameObject WinText;
    public GameObject LoseText;

    private bool changingLifeAmount = true;

    //Instantiater 2 liv på starten ettersom at spiller starter med 3 liv.
    //Gjør at spilleren har 3 liv visuelt, isteden for bare 1 på plass nr. 3.
    void Start()
    {
        //Instantiater HealthPoint 1 på start, og gir den navnet "HealthBlock1".
        HealthPoint = (GameObject)Instantiate(HealthBlock, HealthSlot1.position, HealthSlot1.rotation);
        HealthPoint.name = "HealthBlock1";

        //Instantiater HealthPoint 2 på start, og gir den navnet "HealthBlock2".
        HealthPoint = (GameObject)Instantiate(HealthBlock, HealthSlot2.position, HealthSlot2.rotation);
        HealthPoint.name = "HealthBlock2";
    }

    void OnTriggerEnter(Collider other)
    {
        //Minuser et liv fra Player når den blir truffet av en EnemyBullet.
        if(other.transform.tag == "BreakEnemyBullet")
        {
            life = life -1;
            changingLifeAmount = true;
        }

        //Plusser et liv til Player når den blir truffet av en EnemyGift.
        if(other.transform.tag == "EnemyGift")
        {
            life = life +1;
            changingLifeAmount = true;
        }
    }

    void Update()
    {
        //Kode for testing av spill. Kan bruke "L" og "O" til å legge til og trekke fra liv:

        // if(Input.GetKeyDown(KeyCode.L))
        // {
        //     life = life - 1;
        //     Debug.Log("-1");
        //     changingLifeAmount = true;
        // }

        // if(Input.GetKeyDown(KeyCode.O))
        // {
        //     life = life + 1;
        //     Debug.Log("+1");
        //     changingLifeAmount = true;
        // }

    
        if(life == 0)
        {
            //Om liv er null fjærner den GameObject (player), og instantiater en eksplosjons effekt, og en hyggelig melding :D.
            //Fjærner også alle mulig eksisterende liv.
            Destroy(gameObject);
            Instantiate(DeathEffect, transform.position, transform.rotation * Quaternion.Euler (90f, 0f, 0f));
            Destroy(GameObject.Find("HealthBlock1"));
            Destroy(GameObject.Find("HealthBlock2"));
            Destroy(GameObject.Find("HealthBlock3"));
            Destroy(GameObject.Find("HealthBlock4"));
            Destroy(GameObject.Find("HealthBlock5"));
            Destroy(GameObject.Find("HealthBlock6"));
            Destroy(GameObject.Find("HealthBlock7"));
            Destroy(GameObject.Find("HealthBlock8"));
            Destroy(GameObject.Find("HealthBlock9"));
            if (HealthBlock1Exists == true)
            {
                Instantiate(MinusHealthParticles, HealthSlot1.position, HealthSlot1.rotation * Quaternion.Euler (90f, 0f, 0f));
                Instantiate(LoseText);
            }
        }


        //For å legge til/trekke fra liv visuelt.
        else if(life == 1 && changingLifeAmount == true)
        {   
            //Hvis liv 1 ikke fantes fra før, blir en HealthBlock (det som viser hvor mange liv du har) instantiatet.
            changingLifeAmount = false;
            if(HealthBlock1Exists == false)
            {
                HealthPoint = (GameObject)Instantiate(HealthBlock, HealthSlot1.position, HealthSlot1.rotation);
                HealthPoint.name = "HealthBlock1";
                HealthBlock1Exists = true;
            }

            //Prøver altid å fjærne HealthBlocken som ligger en høyere.
            Destroy(GameObject.Find("HealthBlock2"));
            if (HealthBlock2Exists == true)
            {
                Instantiate(MinusHealthParticles, HealthSlot2.position, HealthSlot2.rotation * Quaternion.Euler (90f, 0f, 0f));
            }
            HealthBlock2Exists = false;
        }



        //For å legge til/trekke fra liv visuelt.
        else if(life == 2 && changingLifeAmount == true)
        {   
            //Hvis liv 2 ikke fantes fra før, blir en HealthBlock instantiatet.
            changingLifeAmount = false;
            if(HealthBlock2Exists == false)
            {
                HealthPoint = (GameObject)Instantiate(HealthBlock, HealthSlot2.position, HealthSlot2.rotation);
                HealthPoint.name = "HealthBlock2";
                HealthBlock2Exists = true;
            }

            //Prøver altid å fjærne HealthBlocken som ligger en høyere.
            Destroy(GameObject.Find("HealthBlock3"));
            if (HealthBlock3Exists == true)
            {
                Instantiate(MinusHealthParticles, HealthSlot3.position, HealthSlot3.rotation * Quaternion.Euler (90f, 0f, 0f));
            }
            HealthBlock3Exists = false;
        }



        else if(life == 3 && changingLifeAmount == true)
        {
            changingLifeAmount = false;
            if(HealthBlock3Exists == false)
            {
                HealthPoint = (GameObject)Instantiate(HealthBlock, HealthSlot3.position, HealthSlot3.rotation);
                HealthPoint.name = "HealthBlock3";
                HealthBlock3Exists = true;
            }
            Destroy(GameObject.Find("HealthBlock4"));
            if (HealthBlock4Exists == true)
            {
                Instantiate(MinusHealthParticles, HealthSlot4.position, HealthSlot4.rotation * Quaternion.Euler (90f, 0f, 0f));
            }
            HealthBlock4Exists = false;
        }



        else if(life == 4 && changingLifeAmount == true)
        {
            changingLifeAmount = false;
            if(HealthBlock4Exists == false)
            {
                HealthPoint = (GameObject)Instantiate(HealthBlock, HealthSlot4.position, HealthSlot4.rotation);
                HealthPoint.name = "HealthBlock4";
                HealthBlock4Exists = true;
            }
            Destroy(GameObject.Find("HealthBlock5"));
            if (HealthBlock5Exists == true)
            {
                Instantiate(MinusHealthParticles, HealthSlot5.position, HealthSlot5.rotation * Quaternion.Euler (90f, 0f, 0f));
            }
            HealthBlock5Exists = false;
        }



        else if(life == 5 && changingLifeAmount == true)
        {
            changingLifeAmount = false;
            if(HealthBlock5Exists == false)
            {
                HealthPoint = (GameObject)Instantiate(HealthBlock, HealthSlot5.position, HealthSlot5.rotation);
                HealthPoint.name = "HealthBlock5";
                HealthBlock5Exists = true;
            }
            Destroy(GameObject.Find("HealthBlock6"));
            if (HealthBlock6Exists == true)
            {
                Instantiate(MinusHealthParticles, HealthSlot6.position, HealthSlot6.rotation * Quaternion.Euler (90f, 0f, 0f));
            }
            HealthBlock6Exists = false;
        }



        else if(life == 6 && changingLifeAmount == true)
        {
            changingLifeAmount = false;
            if(HealthBlock6Exists == false)
            {
                HealthPoint = (GameObject)Instantiate(HealthBlock, HealthSlot6.position, HealthSlot6.rotation);
                HealthPoint.name = "HealthBlock6";
                HealthBlock6Exists = true;
            }
            Destroy(GameObject.Find("HealthBlock7"));
            if (HealthBlock7Exists == true)
            {
                Instantiate(MinusHealthParticles, HealthSlot7.position, HealthSlot7.rotation * Quaternion.Euler (90f, 0f, 0f));
            }
            HealthBlock7Exists = false;
        }



        else if(life == 7 && changingLifeAmount == true)
        {
            changingLifeAmount = false;
            if(HealthBlock7Exists == false)
            {
                HealthPoint = (GameObject)Instantiate(HealthBlock, HealthSlot7.position, HealthSlot7.rotation);
                HealthPoint.name = "HealthBlock7";
                HealthBlock7Exists = true;
            }
            Destroy(GameObject.Find("HealthBlock8"));
            if (HealthBlock8Exists == true)
            {
                Instantiate(MinusHealthParticles, HealthSlot8.position, HealthSlot8.rotation * Quaternion.Euler (90f, 0f, 0f));
            }
            HealthBlock8Exists = false;
        }



        else if(life == 8 && changingLifeAmount == true)
        {
            changingLifeAmount = false;
            if(HealthBlock8Exists == false)
            {
                HealthPoint = (GameObject)Instantiate(HealthBlock, HealthSlot8.position, HealthSlot8.rotation);
                HealthPoint.name = "HealthBlock8";
                HealthBlock8Exists = true;
            }
            Destroy(GameObject.Find("HealthBlock9"));
            if (HealthBlock9Exists == true)
            {
                Instantiate(MinusHealthParticles, HealthSlot9.position, HealthSlot9.rotation * Quaternion.Euler (90f, 0f, 0f));
            }
            HealthBlock9Exists = false;
        }



        else if(life == 9 && changingLifeAmount == true)
        {
            changingLifeAmount = false;
            if(HealthBlock9Exists == false)
            {
                HealthPoint = (GameObject)Instantiate(HealthBlock, HealthSlot9.position, HealthSlot9.rotation);
                HealthPoint.name = "HealthBlock9";
                HealthBlock9Exists = true;
            }
            Destroy(GameObject.Find("HealthBlock10"));
            if (HealthBlock10Exists == true)
            {
                Instantiate(MinusHealthParticles, HealthSlot10.position, HealthSlot10.rotation * Quaternion.Euler (90f, 0f, 0f));
            }
            HealthBlock10Exists = false;
        }



        else if(life == 10 && changingLifeAmount == true)
        {
            changingLifeAmount = false;
            if(HealthBlock10Exists == false)
            {
                HealthPoint = (GameObject)Instantiate(HealthBlock, HealthSlot10.position, HealthSlot10.rotation);
                HealthPoint.name = "HealthBlock10";
                HealthBlock10Exists = true;
            }
            Time.timeScale = 0f;
            Instantiate(WinText);
        }



        //Passer på at du ikke kan få noen flere liv en 10.
        else if(life > 10)
        {
            life = 10;
        }
    }
}
