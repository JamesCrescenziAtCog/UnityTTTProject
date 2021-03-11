using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(OnClickScreen))]
public class ClickedObjGetter : MonoBehaviour
{

    [Serializable]
    /// <summary>
    /// Function definition for a GetObj event.
    /// </summary>
    public class ScreenClickEvent : UnityEvent { }

    // Event delegates triggered on click.
    [FormerlySerializedAs("onGetObject")]
    [SerializeField]
    private ScreenClickEvent m_onGetObj = new ScreenClickEvent();

    public ScreenClickEvent onGetObject
    {
        get { return m_onGetObj; }
        set { m_onGetObj = value; }
    }

    private OnClickScreen _onClickScreen;
    [SerializeField]
    private LayerMask targetLayers;
    [SerializeField]
    private float rayDistance;
    [SerializeField]
    private string targetTag;
    public GameObject MostRecentObject { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _onClickScreen = GetComponent<OnClickScreen>();
        _onClickScreen.onClick.AddListener(GetClickedObject);
        MostRecentObject = null;
    }

    public void GetClickedObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        GameObject outObj = null;

        if (RaycastObjGetter.GetObjByTag(ray, targetTag,targetLayers,rayDistance,out outObj))
        {
            MostRecentObject = outObj;
            m_onGetObj.Invoke();

        }
    }

    public void DebugConsoleTextTestMethod(string message)
    {
        Debug.Log(message);
    }
}
