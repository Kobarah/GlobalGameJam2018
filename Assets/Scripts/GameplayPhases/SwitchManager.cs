using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
	public PreparationPhase preparationPhase;
	public EnemyWavesPhase enemyWavesPhase;
	public GameManager gameManager;

	public void SwitchOnPreparationPhase()
	{
		//Debug.Log("Entra nel metodo");
		preparationPhase.enabled = true;
		enemyWavesPhase.enabled = false;
		preparationPhase.OnActivation();
		preparationPhase.maxLinksCount++;
		//gameManager.isPreparationPhase = true;
	}

	public void SwitchOnEnemyWavesPhase()
	{
        Debug.Log("Entra nel metodo");
        enemyWavesPhase.enabled = true;
		preparationPhase.enabled = false;
		enemyWavesPhase.OnActivation();
		gameManager.enemiesPerTurn+=2;
        enemyWavesPhase.enemiesPerTurn += 2;
        gameManager.totalEnemies = enemyWavesPhase.enemiesPerTurn;
        enemyWavesPhase.totalEnemies = enemyWavesPhase.enemiesPerTurn;
    }

}
