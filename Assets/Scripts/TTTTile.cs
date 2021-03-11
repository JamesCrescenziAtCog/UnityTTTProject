using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTTTile : MonoBehaviour
{

    public GameObject symbolObj;

    public void PerformMove(GameObject symbolPrefab,float yOffset)
    {
        //if (symbolObj == null)
      //  {
            symbolObj = Instantiate(symbolPrefab, gameObject.transform.position + new Vector3(0,yOffset,0), Quaternion.identity);
            symbolObj.transform.parent = gameObject.transform;
            
        //}
    }

    public void ResetTile()
    {
        Destroy(symbolObj);
        symbolObj = null;
    }
}
