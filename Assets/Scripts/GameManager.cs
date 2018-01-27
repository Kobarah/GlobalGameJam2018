using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public List<SpiderString> webs;
	public List<GameObject> spiderWebs;
	public GameObject spiderWeb;
	public GameObject cameraMain;
	public int clickCount = 0;
	public int startHP;
	public int currentHP;

	[HideInInspector]
	public GameObject end;
	[HideInInspector]
	public GameObject start;

	public static GameManager instance = null;

	private void Awake()
	{
		{
			//Check if instance already exists
			if (instance == null)

			//if not, set instance to this
			instance = this;

			//If instance already exists and it's not this:
			else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);

			//Sets this to not be destroyed when reloading scene
			DontDestroyOnLoad(gameObject);
		}
	}

	void Start()
	{
		webs = new List<SpiderString>();
		spiderWebs = new List<GameObject>();
	}

	public void AddWebs()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(cameraMain.transform.position, ray.direction, out hit))
		{
			if (hit.transform.tag == "WebJoint")
			{
				Debug.Log(hit.transform);
				if (clickCount == 0)
				{
					start = hit.transform.gameObject;
					Debug.Log("click 0");
				}
				else if (clickCount == 1)
				{
					end = hit.transform.gameObject;
					SpiderString webString = new SpiderString(start, end);
					webs.Add(webString);
					Debug.Log("click 1");
				}
				else
				{
					start = end;
					end = hit.transform.gameObject;
					SpiderString webString = new SpiderString(start, end);
					webs.Add(webString);
					Debug.Log("click 2+");
				}
				clickCount++;
			}
		}
	}

	void Update()
	{
		for (int i = 0; i < webs.Count; i++)
		{
			webs[i].buildString();
			webs[i].buildTemporaryString(webs[webs.Count - 1].lineToJoint);
		}

		PlaceSpiderStrings();

		//if (Input.GetMouseButtonDown(0))
		//{
		//	AddWebs();
		//}
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
