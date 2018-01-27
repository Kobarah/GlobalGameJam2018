using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderString : ScriptableObject {

    //VARIABLES
    private GameObject fromJoint; //Starting point of the string
    private GameObject toJoint; //Ending point of the string
    private GameObject lineFromJoint; //Starting point of the renderer
    private GameObject lineToJoint; //Ending point of the renderer
    public GameObject joint;

    //GET METHODS
    public Vector3 FromJoint
    {
        get
        {
            return fromJoint.transform.position;
        }
    }

    public Vector3 ToJoint
    {
        get
        {
            return toJoint.transform.position;
        }
    }

    //CONSTRUCTOR METHOD
    public SpiderString(GameObject from, GameObject to)
    {
        fromJoint = from;
        toJoint = to;

        joint = GameObject.Find("GameManager").GetComponent<WebRaycast>().spiderWeb;
        lineFromJoint = Instantiate(joint, fromJoint.transform.position, Quaternion.identity);
        lineToJoint = Instantiate(joint, toJoint.transform.position, Quaternion.identity);
    }

    //RENDERER BUILD METHOD
    public void buildString ()
    {
        Physics.Raycast(fromJoint.transform.position, (toJoint.transform.position - fromJoint.transform.position));
        Debug.DrawRay(fromJoint.transform.position, (toJoint.transform.position - fromJoint.transform.position), Color.red);

        lineFromJoint.GetComponent<LineRenderer>().SetPosition(0, fromJoint.transform.position);
        lineFromJoint.GetComponent<LineRenderer>().SetPosition(1, toJoint.transform.position);
    }
}
