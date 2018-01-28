using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWavesPhase : GameManager
{
	public override void OnActivation()
	{
		//ClearWebstrings();

		for (int i = 0; i < spawnPoints.Count; i++)
		{
			//spawnPoints[i].transform.SetActive(true);
		}
	}

	//public override void ClearWebstrings()
	//{
	//}

	//public override void MoveWebstrings()
	//{
	//}
}
