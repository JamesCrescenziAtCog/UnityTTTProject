using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastObjGetter
{


    public static bool GetObjByTag(Ray ray,string tag, LayerMask layermask, float distance, out GameObject hitObj)
    {
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, distance, layermask))
        {
            if(hit.collider.gameObject.tag==tag)
            {
                hitObj = hit.collider.gameObject;
                return true;
            }
        }

        hitObj = null;
        return false;
    }

}
