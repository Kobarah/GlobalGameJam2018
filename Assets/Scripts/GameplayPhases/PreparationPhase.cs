using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparationPhase : GameManager
{
	enum PreparationStage
	{
		SpiderStringPlacement,
		TrapPlacement
	};

	PreparationStage currentStage;
	public int currentTrapID;

	private void Update()
	{
		PlaceSpiderStrings();
	}

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

	public void PlaceSpiderStrings()
	{
		if (currentStage == PreparationStage.SpiderStringPlacement)
		{
			// modalità piazzamento fili
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
