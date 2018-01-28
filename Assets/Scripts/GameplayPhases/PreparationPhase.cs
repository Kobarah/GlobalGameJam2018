﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparationPhase : GameManager
{
	public enum PreparationStage
	{
		SpiderStringPlacement,
		TrapPlacement
	};

	public int currentTrapID;
	public PreparationStage currentStage = PreparationStage.SpiderStringPlacement;

	public override void Update()
	{
		base.Update();
		PlaceSpiderStrings();
	}

	public override void OnActivation()
	{
		currentStage = PreparationStage.SpiderStringPlacement;
		ClearWebstrings();
	}

	//public void ChangeStage()
	//{
	//	// if (contatore nella condizione corretta)
	//	{
	//		currentStage = PreparationStage.TrapPlacement;
	//	}
	//}

	public override void PlaceSpiderStrings()
	{
		if (this.currentStage == PreparationStage.SpiderStringPlacement && Input.GetMouseButtonDown(0))
		{
			AddWebs();
		}
	}

	// chiamata da pulsante HUD
	public void PlaceTraps(int trapID)
	{
		if (currentStage == PreparationStage.TrapPlacement)
		{
			currentTrapID = trapID;
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
