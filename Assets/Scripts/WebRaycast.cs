using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebRaycast : MonoBehaviour
{
    public List<SpiderString> webs;
    public List<GameObject> spiderWebs;
    public GameObject spiderWeb;
    public GameObject cameraMain;
    GameObject start;
    GameObject end;
    public int clickCount = 0;
	
	void Start ()
    {
        webs = new List<SpiderString>();
        spiderWebs = new List<GameObject>();
    }
	
	void Update ()
    {
        //if (webs.Count > 1)
        //{
        //    for (int i = 0; i < webs.Count; i++)
        //    {
        //        if (i > 0)
        //        {
        //            webs[i].buildString();
        //        }
        //    }
        //}

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(cameraMain.transform.position,ray.direction, out hit))
            {
                if (hit.transform.tag == "WebJoint")
                {
                    Debug.Log(hit.transform);
                    if (clickCount == 0)
                    {
                        start = hit.transform.gameObject;
                        Debug.Log("click 0");
                    }
                    else if(clickCount == 1)
                    {
                        end = hit.transform.gameObject;
                        SpiderString webString = new SpiderString(start,end);
                        webs.Add(webString);
                        Debug.Log("click 1");
                    }
                    else
                    {
                        start = end;
                        end = hit.transform.gameObject;
                        SpiderString webString = new SpiderString(start, end);
                        webs.Add(webString);
                        Debug.Log("click 2+");
                    }
                    clickCount++;
                }          
            }
        }
	}
}
