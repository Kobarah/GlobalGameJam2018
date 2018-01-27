using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderString : ScriptableObject {

    //VARIABLES
    [HideInInspector] public GameObject fromJoint; //Starting point of the string
    [HideInInspector] public GameObject toJoint; //Ending point of the string
    [HideInInspector] public GameObject lineFromJoint; //Starting point of the renderer
    [HideInInspector] public GameObject lineToJoint; //Ending point of the renderer
    [HideInInspector] public GameObject lastJoint;
    [HideInInspector] public GameObject joint;

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

		joint = GameObject.Find("GameManager").GetComponent<GameManager>().spiderWeb;
        lineFromJoint = Instantiate(joint, fromJoint.transform.position, Quaternion.identity);
        lineToJoint = Instantiate(joint, toJoint.transform.position, Quaternion.identity);
    }

    //RENDERER BUILD METHOD
    public void buildString ()
    {
        //Physics.Raycast(fromJoint.transform.position, (toJoint.transform.position - fromJoint.transform.position));
        //Debug.DrawRay(fromJoint.transform.position, (toJoint.transform.position - fromJoint.transform.position), Color.red);
        setActualEnemy();

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

    private void setActualEnemy()
    {
        RaycastHit hit;

        if (Physics.Raycast(fromJoint.transform.position, (toJoint.transform.position - fromJoint.transform.position), out hit))
        {
            if (hit.transform.tag == "Enemy")
            {
                Traps startTrap = fromJoint.GetComponent<JointInfo>().activeTrap.GetComponent<Traps>();
                Traps toTrap = toJoint.GetComponent<JointInfo>().activeTrap.GetComponent<Traps>();

                if (hit.distance < startTrap.range)
                {
                    fromJoint.GetComponent<JointInfo>().activeTrap.GetComponent<Traps>().enemy = hit.transform.gameObject;
                }

                if (Vector3.Distance(hit.transform.position, toJoint.transform.position) < toTrap.range)
                {
                    toJoint.GetComponent<JointInfo>().activeTrap.GetComponent<Traps>().enemy = hit.transform.gameObject;
                }
            }
        }
    }

    public override bool Equals(object other)
    {
        SpiderString ss = (SpiderString)other;
        return (((this.toJoint.transform.position == ss.toJoint.transform.position) && (this.fromJoint.transform.position == ss.fromJoint.transform.position)) 
            || ((this.toJoint.transform.position == ss.fromJoint.transform.position) && (this.fromJoint.transform.position == ss.toJoint.transform.position)));
    }
}
