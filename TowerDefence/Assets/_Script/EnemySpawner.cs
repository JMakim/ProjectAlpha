using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate=3;
    public GameObject enemyPrefab;
    public Transform enemyCollection;
    float timer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Instantiate(enemyPrefab, this.transform.position, Quaternion.identity, enemyCollection);
            timer = 1 / spawnRate;
        }
    }
}
