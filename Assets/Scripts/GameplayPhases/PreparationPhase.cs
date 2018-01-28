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

		for (int i = 0; i < spawnPoints.Count; i++)
		{
			spawnPoints[i].SetActive(false);
		}
	}

	public void ChangeStage()
	{
		if (webs.Count >= maxLinksCount)
		{
			currentStage = PreparationStage.TrapPlacement;
		}
	}

	/*public override void PlaceSpiderStrings()
	{
		if (this.currentStage == PreparationStage.SpiderStringPlacement && Input.GetMouseButtonDown(0))
		{
			AddWebs();
		}
		if (this.currentStage == PreparationStage.TrapPlacement && Input.GetMouseButtonDown(0))
		{
			AddTurrets();
		}
	}*/

	// Instantiates traps
	public void PlaceTraps(int trapID)
	{
		if (currentStage == PreparationStage.TrapPlacement)
		{
			for (int i = 0; i < turrets.Count; i++)
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

    public void AddWebs(GameObject joint)
	{
        if (clickCount == 0)
        {
            start = joint;
            clickCount++;
        }
        else if (clickCount == 1)
        {
            SpiderString webString = new SpiderString(start, joint);
            if (isLegit(webString))
            {
                webs.Add(webString);
                end = joint;
                Debug.Log(end);
                start = end;
            }
        }
        else
        {
            SpiderString webString = new SpiderString(start, joint);
            if (isLegit(webString))
            {
                webs.Add(webString);
                end = joint;
            }
            clickCount++;
            Debug.Log(clickCount);
        }
	}

	public void AddTurrets(GameObject joint)
	{
        Debug.Log(currentTrapID);
        if (joint.GetComponent<JointInfo>().activeTrap == null && currentTrapID != null)
        {
            joint.GetComponent<JointInfo>().activeTrap = Instantiate(currentTrapID, joint.transform);
            joint.GetComponent<JointInfo>().activeTrap.transform.position = joint.transform.position;
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
