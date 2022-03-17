using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public Transform[] SpawnPoints;
    public GameObject Enemy;
        

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }



    void SpawnEnemy()
    {
        Instantiate(Enemy, SpawnPoints[Random.Range(0,SpawnPoints.Length)].transform.position, Quaternion.identity);
    }

    private void OnEnable()
    {
        SkeletonBehavior.OnEnemyKilled += SpawnEnemy;
    }
}
