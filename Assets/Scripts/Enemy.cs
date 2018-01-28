using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public int hp;
    public int dmg;
    public float speed;
    public NavMeshAgent agent;
    public Transform nexus;
    [HideInInspector] GameManager _gm;

    private void Awake()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        nexus = _gm.nexus.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(nexus.position);
        agent.speed = speed;
    }

    public void NexusDamage(Animator anim)
    {
            Debug.Log("entro");
        _gm.currentHP -= dmg;
        if (_gm.currentHP <= 0)
        {
            Debug.Log("you lose");
        }
        Destroy(gameObject);
        _gm.enemyCount--;
        anim.SetTrigger("Damage");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Nexus")
        {
           NexusDamage(other.transform.GetChild(0).GetComponent<Animator>());
        }
    }

    private void Update()
    {
        transform.DOLookAt(Camera.main.transform.position, 0.1f);
        if(hp <= 0)
        {
            Destroy(gameObject);
            _gm.enemyCount--;
        }
    }

}
