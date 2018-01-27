using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public SwitchManager switchManager;

	public List<SpiderString> webs;
	public List<GameObject> spiderWebs;
	public GameObject spiderWeb;
	public GameObject cameraMain;
	public bool isPreparationPhase;			// true = preparation phase; false = enemy waves phase
	public int clickCount = 0;
	public int startHP;
	public int currentHP;
	public int enemiesPerTurn;

	[HideInInspector]
	public int enemyCount;
	[HideInInspector]
	public GameObject end;
	[HideInInspector]
	public GameObject start;

	void Start()
	{
		webs = new List<SpiderString>();
		spiderWebs = new List<GameObject>();
		switchManager = FindObjectOfType<SwitchManager>().GetComponent<SwitchManager>();
	}

	public virtual void Update()
	{
		for (int i = 0; i < webs.Count; i++)
		{
			webs[i].buildString();
			//webs[i].buildTemporaryString(webs[webs.Count - 1].lineToJoint);
		}

		// Switches to Preparation Phase
		if (!isPreparationPhase && enemiesPerTurn == 0 && enemyCount == 0)
		{
			isPreparationPhase = true;
			switchManager.SwitchOnPreparationPhase();
		}
	}

	// Switches to EnemyWavesPhase DA DECOMMENTARE
	public void SwitchOnEnemyWavePhase()
	{
		isPreparationPhase = false;
		switchManager.SwitchOnEnemyWavesPhase();
	}

	public virtual void PlaceSpiderStrings()
	{ }

	public virtual void MoveWebstrings()
	{ }

	public virtual void ClearWebstrings()
	{ }

	public virtual void OnActivation()
	{ }

}
