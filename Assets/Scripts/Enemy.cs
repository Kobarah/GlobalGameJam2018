using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    }

}
