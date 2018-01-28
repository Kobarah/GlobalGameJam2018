using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public SwitchManager switchManager;

    public GameObject nexus;
	public List<GameObject> enemyTypes;
	public List<SpiderString> webs;
	public List<GameObject> spiderWebs;
	public GameObject spiderWeb;
	public GameObject cameraMain;
	public bool isPreparationPhase = true;			// true = preparation phase; false = enemy waves phase
	public int clickCount = 0;
	public int startHP;
	public int currentHP;
	public int enemiesPerTurn;
	private bool isPaused;

	//[HideInInspector]
	public int enemyCount;
	[HideInInspector]
	public GameObject end;
	[HideInInspector]
	public GameObject start;

	public GameObject pauseCentralButton;
	public Button pauseEscButton;
	public Button resumeButton;
	public Button gameOverButton;

    void Start()
	{
		webs = new List<SpiderString>();
		spiderWebs = new List<GameObject>();
		switchManager = FindObjectOfType<SwitchManager>().GetComponent<SwitchManager>();
		isPreparationPhase = true;
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
			switchManager.SwitchOnPreparationPhase();
			isPreparationPhase = true;
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			PauseGame();
		}
	}

	// Switches to EnemyWavesPhase
	public void SwitchOnEnemyWavePhase()
	{
		isPreparationPhase = false;
		switchManager.SwitchOnEnemyWavesPhase();
	}

	public void PauseGame()
	{
		if (isPaused)
		{
			pauseCentralButton.gameObject.SetActive(false);
			pauseEscButton.gameObject.SetActive(true);
			resumeButton.gameObject.SetActive(false);
			Time.timeScale = 1;
			isPaused = false;
		}
		else
		{
			pauseCentralButton.gameObject.SetActive(true);
			pauseEscButton.gameObject.SetActive(false);
			resumeButton.gameObject.SetActive(true);
			Time.timeScale = 0;
			isPaused = true;
		}
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
