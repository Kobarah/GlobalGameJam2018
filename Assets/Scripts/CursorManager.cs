using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CursorManager : MonoBehaviour
{
    public ParticleSystem mouseTrail;
    public ParticleSystem.Particle[] trailEmission;
    public Gradient color;
    public float cRange = 0;

    void Start ()
    {
		
	}

    public void StartParticle(Transform target )
    {
        mouseTrail.transform.position = target.position;
        //mouseTrail.transform.rotation = Quaternion.LookRotation(target.normal);
        var emission = mouseTrail.emission;
        emission.enabled = true;
    }

    public void KillAllParticles(ParticleSystem mouseTrail)
    {
        if (trailEmission == null || trailEmission.Length < mouseTrail.main.maxParticles)
            trailEmission = new ParticleSystem.Particle[mouseTrail.main.maxParticles];

        int numParticlesAlive = mouseTrail.GetParticles(trailEmission);

        for (int i = 0; i < numParticlesAlive; i++)
        {
            float currentSize = trailEmission[i].GetCurrentSize(mouseTrail);

            trailEmission[i].startColor = color.Evaluate(cRange);
        }

        // Apply the particle changes to the particle system
        mouseTrail.SetParticles(trailEmission, numParticlesAlive);

        var emission = mouseTrail.emission;
        emission.enabled = false;
    }

    void Update ()
    {
        mouseTrail.transform.DOLookAt(Input.mousePosition, 0.1f);
    }
}
