using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform[] spawnPositions;
    public GameObject c1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void respawnCrate()
    {
        int pos = Random.Range(0, spawnPositions.Length);
        c1.transform.position = spawnPositions[pos].position;
        c1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
