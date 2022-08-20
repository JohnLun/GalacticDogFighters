using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public Player1 p1;
    public Player2 p2;

    public GameObject p1GO;
    public GameObject p2GO;

    public HealthBar p1Health;
    public HealthBar p2Health;

    public Transform p1RespawnPoint;
    public Transform p2RespawnPoint;

    private int p1Score;
    private int p2Score;
    // Start is called before the first frame update
    void Start()
    {
        score.text = p1Score + ":" + p2Score;
    }

    // Update is called once per frame
    void Update()
    {
        if(p1.currentHealth == 0)
        {
            p2Score++;
            p1GO.transform.position = p1RespawnPoint.position;
            p2GO.transform.position = p2RespawnPoint.position;
            score.text = p1Score + ":" + p2Score;
            p1Health.SetHealth(5);
            p2Health.SetHealth(5);
            p1.currentHealth = p1.maxHealth;
            p2.currentHealth = p2.maxHealth;
            SoundManager.PlaySound("destroy");
        }
        if(p2.currentHealth == 0)
        {
            p1Score++;
            p1GO.transform.position = p1RespawnPoint.position;
            p2GO.transform.position = p2RespawnPoint.position;
            score.text = p1Score + ":" + p2Score;
            p1Health.SetHealth(5);
            p2Health.SetHealth(5);
            p1.currentHealth = p1.maxHealth;
            p2.currentHealth = p2.maxHealth;
            SoundManager.PlaySound("destroy");
        }
    }
}
