using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparationPhase : GameManager
{
	public enum PreparationStage
	{
		SpiderStringPlacement,
		TrapPlacement
	};

	public List<GameObject> turrets;
	public int maxLinksCount = 5;
	public GameObject currentTrapID;
	public PreparationStage currentStage = PreparationStage.SpiderStringPlacement;

	public override void Update()
	{
		base.Update();
		PlaceSpiderStrings();
		ChangeStage();
	}

	public override void OnActivation()
	{
		currentStage = PreparationStage.SpiderStringPlacement;
		ClearWebstrings();
	}

	public void ChangeStage()
	{
		if (webs.Count >= maxLinksCount)
		{
			currentStage = PreparationStage.TrapPlacement;
		}
	}

	public override void PlaceSpiderStrings()
	{
		if (this.currentStage == PreparationStage.SpiderStringPlacement && Input.GetMouseButtonDown(0))
		{
			AddWebs();
		}
		if (this.currentStage == PreparationStage.TrapPlacement && Input.GetMouseButtonDown(0))
		{
			AddTurrets();
		}
	}

	// Instantiates traps
	public void PlaceTraps(int trapID)
	{
		if (currentStage == PreparationStage.TrapPlacement)
		{
			for (int i = 0; i < turrets.Count - 1; i++)
			{
				if (trapID == i)
				{
					currentTrapID = turrets[i].gameObject;
				}
			}
		}
	}

	public override void ClearWebstrings()
	{
	}

	public override void MoveWebstrings()
	{		
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
				}
				else if (clickCount == 1)
				{
                    SpiderString webString = new SpiderString(start, hit.transform.gameObject);
                    if (isLegit(webString))
                    {
                        webs.Add(webString);
                        end = hit.transform.gameObject;
                    }
                }
				else
				{
					start = end;
					SpiderString webString = new SpiderString(start, hit.transform.gameObject);
                    if (isLegit(webString))
                    {
                        webs.Add(webString);
                        end = hit.transform.gameObject;
                    }
                }
				clickCount++;
                Debug.Log(clickCount);
			}
		}
	}

	public void AddTurrets()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(cameraMain.transform.position, ray.direction, out hit))
		{
			if (hit.transform.tag == "WebJoint")
			{
				if (hit.transform.GetComponent<JointInfo>().activeTrap == null && currentTrapID != null)
				{					
					hit.transform.GetComponent<JointInfo>().activeTrap = Instantiate(currentTrapID, hit.transform);
					hit.transform.GetComponent<JointInfo>().activeTrap.transform.position = hit.transform.position;
				}
			}
		}
	}

	public bool isLegit (SpiderString ss)
    {
        if (ss.fromJoint == ss.toJoint)
        {
            return false;
        }

        for (int i = 0; i < webs.Count - 1; i++)
        {
            if (webs[i].Equals(ss))
            {
                return false;
            }
        }

        return true;
    }

}
