using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class Traps : MonoBehaviour
{
    public float fireRate;
    float timer;
    public int dmg;
    public float range;
    public GameObject enemy;

    private void Awake()
    {
        timer = fireRate;
        transform.DOLookAt(Camera.main.transform.position, 0.1f);
    }

    public void DamageEnemy(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().hp -= dmg;
        if (enemy.GetComponent<Enemy>().hp <= 0)
            Destroy(enemy);
    }

    public void Engage(GameObject enemy)
    {
        transform.DOLookAt(enemy.transform.position, 0.1f);
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            DamageEnemy(enemy);
            timer = fireRate;
        }
    }

    private void Update()
    {
        
        if (enemy != null)
        {
            Engage(enemy);
        }
    }

}
