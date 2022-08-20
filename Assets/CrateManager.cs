using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateManager : MonoBehaviour
{
    public Player1 p1;
    public Player2 p2;
    public GameObject crate;
    public PowerUpManager pum;

    private void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int powerUp = Random.Range(1, 3);
        if (collision.CompareTag("Player1"))
        {
            if(powerUp == 1)
            {
                /*p1.regShot = true;
                p1.hm = false;*/
                p1.isRegShot();
            }
            else if (powerUp == 2)
            {
                /*p1.regShot = false;
                p1.hm = true;*/
                p1.isHomingMissile();
            }
            crate.SetActive(false);
            pum.respawnCrate();
        } else if (collision.CompareTag("Player2"))
        {
            powerUp = Random.Range(1, 3);
            if (powerUp == 1)
            {
                p2.regShot = true;
                p2.hmShot = false;
            }
            else if (powerUp == 2)
            {
                p2.regShot = false;
                p2.hmShot = true;
            }
            crate.SetActive(false);
            pum.respawnCrate();
        }
        
    }
    
}
