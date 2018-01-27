using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movements : MonoBehaviour
{
    public List<Transform> joints;
    public float movementTime;
    public Vector3 centerPosition;
    List<Vector3> originalJoints;
    public float range;

    void Awake ()
    {
        originalJoints = new List<Vector3>();
		for(int i =0; i < joints.Count; i++)
        {
            originalJoints.Add(joints[i].position) ;
            centerPosition += joints[i].position;
        }
        centerPosition /= joints.Count;
	}
	
	void Update ()
    {
		if(Input.GetKey(KeyCode.Q))
        {
            Vector3 destination = (originalJoints[0] - centerPosition).normalized * range;
            destination.y = 0;
            joints[0].DOMove(destination,movementTime);
        }
        else
        {
            joints[0].DOMove(originalJoints[0], movementTime*2);
        }
        if (Input.GetKey(KeyCode.W))
        {

        }
        if (Input.GetKey(KeyCode.E))
        {

        }
        if (Input.GetKey(KeyCode.R))
        {

        }


        if (Input.GetKey(KeyCode.P))
        {

        }
        if (Input.GetKey(KeyCode.O))
        {

        }
        if (Input.GetKey(KeyCode.I))
        {

        }
        if (Input.GetKey(KeyCode.U))
        {

        }
    }
}
