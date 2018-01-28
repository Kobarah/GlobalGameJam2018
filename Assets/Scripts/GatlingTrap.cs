using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class GatlingTrap : Traps
{

    public override void DamageEnemy(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().hp -= dmg;
    }
}
