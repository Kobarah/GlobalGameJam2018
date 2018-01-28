using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnEnemyType { enemy1 = 0, enemy2 = 1, enemy3 = 2, Random = 3};

public class EnemySpawn : MonoBehaviour
{
    public float SpawnTime = 5;
    public SpawnEnemyType Choose;
    public float timer;
    [HideInInspector] public GameManager _gm;
    [HideInInspector] public EnemyWavesPhase enemyWavesPhase;


    void Awake()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyWavesPhase = GameObject.Find("EnemyWavesPhase").GetComponent<EnemyWavesPhase>();

        timer = SpawnTime;
    }

    void SpawnEnemy(SpawnEnemyType enemyType)
    {
        if(enemyType == SpawnEnemyType.Random)
        {
            Vector3 pos = gameObject.transform.position;
            Quaternion rot = gameObject.transform.rotation;
            Instantiate(_gm.enemyTypes[Random.Range(1,3)], pos, rot);
            _gm.enemyCount++;
            //enemyWavesPhase.enemyCount++;
        }
        else
        {
            Vector3 pos = gameObject.transform.position;
            Quaternion rot = gameObject.transform.rotation;
            Instantiate(_gm.enemyTypes[(int)enemyType], pos, rot);
            _gm.enemyCount++;
            //enemyWavesPhase.enemyCount++;
        }

		_gm.totalEnemies--;
        //enemyWavesPhase.totalEnemies--;
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
            if (_gm.totalEnemies > 0)
            {
                SpawnEnemy(Choose);
                timer = SpawnTime;
            }
        }
    }
}