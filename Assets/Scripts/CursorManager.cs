using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public ParticleSystem mouseTrail;
    public ParticleSystem.Particle[] trailEmission;
    public Gradient color;
    public float cRange = 0;

    void Start ()
    {
		
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

    }

    void Update ()
    {
		
	}
}
