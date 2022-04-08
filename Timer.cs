using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float timer = 0f;
    private float bulletSpeedTimer = 0f;
    public Text timerText;
    public EnemyBullet EnemyBullet;

    public bool gameStarted = false;

    void Start()
    {
        //Stopper tid.
        Time.timeScale = 0f;
        
        //Passer på at EnemyBullet har speed 5 når spillet starter.
        EnemyBullet.speed = 5f;
    }
    
    void Update() 
    {   
        //Gjør at timeren bruker sekunder og ikke frames.
        timer += Time.deltaTime;
        double b = System.Math.Round (timer, 2);
        timerText.text = b.ToString ();


        //Gjør at bulletSpeedTimer bruker sekunder og ikke frames.
        bulletSpeedTimer += Time.deltaTime;

        //Hvert 30. sekund blir EnemyBullet speed raskere.
        if(bulletSpeedTimer >= 30)
        {
            bulletSpeedTimer = 0f;
            EnemyBullet.speed = EnemyBullet.speed + 1f;
        }

        
        DisplayTime(timer);

        //Starter spillet når man trykker på space.
        if (gameStarted == false && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            Destroy(GameObject.Find("TextStart"));
        }
    }

    //Gjør timeren til et minutt-sekund format.
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
