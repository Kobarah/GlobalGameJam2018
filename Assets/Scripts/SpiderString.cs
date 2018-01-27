using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderString : ScriptableObject {

    //VARIABLES
    private GameObject fromJoint; //Starting point of the string
    private GameObject toJoint; //Ending point of the string
    private GameObject lineFromJoint; //Starting point of the renderer
    public GameObject lineToJoint; //Ending point of the renderer
    public GameObject lastJoint;
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

        joint = GameManager.instance.spiderWeb;
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

    public void buildTemporaryString(GameObject lj)
    {
        lastJoint = lj;
        lastJoint.GetComponent<LineRenderer>().SetPosition(0, lastJoint.transform.position);
        lastJoint.GetComponent<LineRenderer>().SetPosition(1, GetCurrentMousePosition().GetValueOrDefault());
    }

    private Vector3? GetCurrentMousePosition()
    {
         var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         var plane = new Plane(Vector3.forward, Vector3.zero);
 
         float rayDistance;
         if (plane.Raycast(ray, out rayDistance))
         {
             return ray.GetPoint(rayDistance);
             
         }
 
         return null;
    }
}
