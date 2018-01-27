using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
	public PreparationPhase preparationPhase;
	public EnemyWavesPhase enemyWavesPhase;

	public void SwitchOnPreparationPhase()
	{
		preparationPhase.enabled = true;
		enemyWavesPhase.enabled = false;
		preparationPhase.OnActivation();
	}

	public void SwitchOnEnemyWavesPhase()
	{
		enemyWavesPhase.enabled = true;
		preparationPhase.enabled = false;
		enemyWavesPhase.OnActivation();
	}

}
