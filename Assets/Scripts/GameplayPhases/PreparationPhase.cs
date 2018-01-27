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

	private void Update()
	{
		PlaceSpiderStrings();
		PlaceTraps();
	}

	PreparationStage currentStage;

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

	public void PlaceTraps()
	{
		if (currentStage == PreparationStage.TrapPlacement)
		{
			// modalità piazzamento trappole
		}
	}

	public override void ClearWebstrings()
	{
	}

	public override void MoveWebstrings()
	{		
	}

}
