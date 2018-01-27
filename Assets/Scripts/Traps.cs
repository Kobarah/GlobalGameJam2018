using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public abstract class Traps : MonoBehaviour
{
    public float fireRate;
    float timer;
    public int dmg;
    public float range;
    public GameObject enemy;

    private void Awake()
    {
        timer = fireRate;
    }

    public abstract void DamageEnemy(GameObject enemy);
   

    public void Engage(GameObject enemy)
    {        
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
