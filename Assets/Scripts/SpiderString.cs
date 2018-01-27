using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderString : MonoBehaviour {

    //VARIABLES
    private Vector3 fromJoint; //Starting point of the string
    private Vector3 toJoint; //Ending point of the string
    private GameObject lineFromJoint;
    private GameObject lineToJoint;
    public GameObject joint;

    //GET METHODS
    public Vector3 FromJoint
    {
        get
        {
            return fromJoint;
        }
    }

    public Vector3 ToJoint
    {
        get
        {
            return toJoint;
        }
    }

    //CONSTRUCTOR METHOD
    public SpiderString(GameObject from, GameObject to)
    {
        fromJoint = from.transform.position;
        toJoint = to.transform.position;
        lineFromJoint = Instantiate(joint, fromJoint, Quaternion.identity);
        lineToJoint = Instantiate(joint, toJoint, Quaternion.identity);
    }


    public void buildString ()
    {
        Physics.Raycast(fromJoint, (fromJoint - toJoint));
        Debug.DrawRay(fromJoint, (fromJoint - toJoint), Color.red);

        lineFromJoint.GetComponent<LineRenderer>().SetPosition(0, fromJoint);
        lineToJoint.GetComponent<LineRenderer>().SetPosition(1, toJoint);
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
