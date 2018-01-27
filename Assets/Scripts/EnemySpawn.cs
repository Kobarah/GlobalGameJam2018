using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnEnemyType { Random = 0, enemy2 = 1, enemy = 2 };

public class EnemySpawn : MonoBehaviour
{
    public float SpawnTime = 5;
    public SpawnEnemyType Choose;
    [HideInInspector] public float timer;
    [HideInInspector] public GameManager _gm;


    void Awake()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        timer = SpawnTime;
    }

    void SpawnEnemy(SpawnEnemyType enemyType)
    {
        if(enemyType == SpawnEnemyType.Random)
        {
            Vector3 pos = gameObject.transform.position;
            Quaternion rot = gameObject.transform.rotation;
           // Instantiate(_gm.enemyTypes[Random.Range(0,3)], pos, rot);
            _gm.enemyCount++;
        }
        else
        {
            Vector3 pos = gameObject.transform.position;
            Quaternion rot = gameObject.transform.rotation;
          //  Instantiate(_gm.enemyTypes[(int)enemyType], pos, rot);
            _gm.enemyCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (_gm.enemyCount < _gm.enemiesPerTurn)
            {
                SpawnEnemy(Choose);
                timer = SpawnTime;
            }
        }

    }
}