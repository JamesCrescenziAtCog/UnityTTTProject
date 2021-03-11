using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


public class OnClickScreen : MonoBehaviour
{
    [SerializeField]
    private KeyCode _triggerKey=KeyCode.Mouse0;


    [Serializable]
    /// <summary>
    /// Function definition for a Screen click event.
    /// </summary>
    public class ScreenClickEvent : UnityEvent { }

    // Event delegates triggered on click.
    [FormerlySerializedAs("onClick")]
    [SerializeField]
    private ScreenClickEvent m_OnClick = new ScreenClickEvent();

    public ScreenClickEvent onClick
    {
        get { return m_OnClick; }
        set { m_OnClick = value; }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_triggerKey))
        {
            m_OnClick.Invoke();
        }

    }


}
