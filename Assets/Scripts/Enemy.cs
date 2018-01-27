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

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(nexus.position);
        agent.speed = speed;
    }

    public void NexusDamage()
    {
            Debug.Log("entro");
        GameManager.instance.currentHP -= dmg;
        if (GameManager.instance.currentHP <= 0)
        {
            Debug.Log("you lose");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Nexus")
        {
           NexusDamage();
        }
    }

    private void Update()
    {
        transform.DOLookAt(Camera.main.transform.position, 0.1f);
    }

}
