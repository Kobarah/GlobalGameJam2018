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

	public PreparationStage currentStage = PreparationStage.SpiderStringPlacement;
	public int currentTrapID;


	//private void Update()
	//{
	//	PlaceSpiderStrings();
	//}

	public override void OnActivation()
	{
		currentStage = PreparationStage.SpiderStringPlacement;
		ClearWebstrings();
	}

	public void ChangeStage()
	{
		// if (contatore nella condizione corretta)
		{
			currentStage = PreparationStage.TrapPlacement;
		}
	}

	public override void PlaceSpiderStrings()
	{
		if (currentStage == PreparationStage.SpiderStringPlacement)
		{
			if (Input.GetMouseButtonDown(0))
			{
				AddWebs();
			}
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

}
