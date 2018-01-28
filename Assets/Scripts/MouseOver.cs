using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    public PreparationPhase preparationPhase;

    void OnMouseOver()
    {
        if (preparationPhase.currentStage == PreparationPhase.PreparationStage.SpiderStringPlacement && Input.GetMouseButtonDown(0))
        {
            preparationPhase.AddWebs(gameObject);
        }
        if (preparationPhase.currentStage == PreparationPhase.PreparationStage.TrapPlacement && Input.GetMouseButtonDown(0))
        {
            preparationPhase.AddTurrets(gameObject);
        }

        transform.GetChild(0).gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
