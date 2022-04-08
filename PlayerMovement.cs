using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 0.1f;
    public float time = 0f;
    public float dodgeTime = 1.0f;
    private bool dodging = false;

    void Update()
    {
        //Bruker Unitys innebyggde player-movement funksjon til å bevege spiller frem og tilbake med enten "A" og "D" eller piltastene.
        float yDirection = Input.GetAxis("Horizontal");

        Vector3 moveDircetion = new Vector3(yDirection, 0.0f).normalized;

        transform.position += moveDircetion * speed;

        //5-dobbler hastigheten til spiller et øyeblikk, som en dodge, når du trykker på "M".
        if(Input.GetKeyDown(KeyCode.M))
        {
            speed = 0.5f;
            dodging = true;
        }
    }

    void FixedUpdate() 
    {   
        //Setter hastigheten din tilbake til normal etter et sekund.
        if (dodging == true) 
        {
            time += Time.deltaTime;
            if(dodgeTime <= time)
            {
                speed = 0.1f;
                time = 0;
                dodging = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {   
        //Plaserer spiller på motsatt side av banen, når de forlater skjermen på venstre side.
        if(other.transform.name == "LeftTeleportWall")
        {
            gameObject.transform.position = new Vector3(11.25f, 0.75f, -13.8f);
        }

        //Plaserer spiller på motsatt side av banen, når de forlater skjermen på høyre side.
        if(other.transform.name == "RightTeleportWall")
        {
            gameObject.transform.position = new Vector3(-12.5f, 0.75f, -13.8f);
        }
    }
}