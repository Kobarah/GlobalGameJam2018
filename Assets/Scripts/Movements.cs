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
    public Animator anim;

    void Awake ()
    {
        originalJoints = new List<Vector3>();
		for(int i =0; i < joints.Count; i++)
        {
            originalJoints.Add(joints[i].position);
            centerPosition += originalJoints[i];
        }
        centerPosition = centerPosition / joints.Count;
	}
	
	void Update ()
    {
		if(Input.GetKey(KeyCode.Q))
        {
            Vector3 destination = (originalJoints[0] - centerPosition).normalized * range;
            Vector3 sum = destination + originalJoints[0];
            joints[0].DOMove(sum, movementTime * 2);
            anim.SetBool("Attack", true);
        }
        else
        {
            joints[0].DOMove(originalJoints[0], movementTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 destination = (originalJoints[1] - centerPosition).normalized * range;
            Vector3 sum = destination + originalJoints[1];
            joints[1].DOMove(sum, movementTime * 2);
            anim.SetBool("Attack", true);
        }
        else
        {
            joints[1].DOMove(originalJoints[1], movementTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            Vector3 destination = (originalJoints[2] - centerPosition).normalized * range;
            Vector3 sum = destination + originalJoints[2];
            joints[2].DOMove(sum, movementTime * 2);
            anim.SetBool("Attack", true);
        }
        else
        {
            joints[2].DOMove(originalJoints[2], movementTime);
        }

        if (Input.GetKey(KeyCode.R))
        {
            Vector3 destination = (originalJoints[3] - centerPosition).normalized * range;
            Vector3 sum = destination + originalJoints[3];
            joints[3].DOMove(sum, movementTime * 2);
            anim.SetBool("Attack", true);
        }
        else
        {
            joints[3].DOMove(originalJoints[3], movementTime);
        }


        if (Input.GetKey(KeyCode.P))
        {
            Vector3 destination = (originalJoints[4] - centerPosition).normalized * range;
            Vector3 sum = destination + originalJoints[4];
            joints[4].DOMove(sum, movementTime * 2);
            anim.SetBool("Attack", true);
        }
        else
        {
            joints[4].DOMove(originalJoints[4], movementTime);
        }

        if (Input.GetKey(KeyCode.O))
        {
            Vector3 destination = (originalJoints[5] - centerPosition).normalized * range;
            Vector3 sum = destination + originalJoints[5];
            joints[5].DOMove(sum, movementTime * 2);
            anim.SetBool("Attack", true);
        }
        else
        {
            joints[5].DOMove(originalJoints[5], movementTime);
        }

        if (Input.GetKey(KeyCode.I))
        {
            Vector3 destination = (originalJoints[6] - centerPosition).normalized * range;
            Vector3 sum = destination + originalJoints[6];
            joints[6].DOMove(sum, movementTime * 2);
            anim.SetBool("Attack", true);
        }
        else
        {
            joints[6].DOMove(originalJoints[6], movementTime);
        }

        if (Input.GetKey(KeyCode.U))
        {
            Vector3 destination = (originalJoints[7] - centerPosition).normalized * range;
            Vector3 sum = destination + originalJoints[7];
            joints[7].DOMove(sum, movementTime * 2);
            anim.SetBool("Attack", true);
        }
        else
        {
            joints[7].DOMove(originalJoints[7], movementTime);
        }

        if(Input.anyKey == false)
        {
            anim.SetBool("Attack", false);
        }
    }
}
