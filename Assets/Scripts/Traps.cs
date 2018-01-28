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
    [HideInInspector] public GameManager _gm;

    private void Awake()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        timer = fireRate;
    }

    public abstract void DamageEnemy(GameObject enemy);
   

    public void Engage(GameObject enemy)
    {        
        if (timer < 0)
        {
            DamageEnemy(enemy);
            timer = fireRate;
        }
    }

    private void Update()
    {
       transform.DOLookAt(Camera.main.transform.position, 0.1f);

        timer -= Time.deltaTime;
        if (enemy != null)
        {
            Engage(enemy);
        }
    }
}
