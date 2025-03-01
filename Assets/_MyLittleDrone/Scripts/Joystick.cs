using System;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public abstract class Joystick 
{
    [SerializeField] protected GameObject m_Obj;

    [SerializeField] protected GameObject m_MarkerObj;

    public bool IsActivated { get; protected set; }

    public virtual void Init()
    {
        Hide();
    }
    public virtual void Show(Vector3 pos)
    {
        m_Obj.transform.position = pos;
        m_Obj.SetActive(true);
        IsActivated = true;
    }

    public virtual void Hide()
    {
        m_Obj.SetActive(false);

        m_MarkerObj.transform.localPosition = Vector3.zero;

        IsActivated = false;
    }

    public abstract void ProcessJoystickActivation(Vector3 pinchPos);
    public abstract Vector3 GetAxis();
}

[Serializable]
public class HorizontalJoystick : Joystick
{
    [SerializeField] private float m_MaxDistance = 0.1f;

    public override Vector3 GetAxis()
    {
        if (!IsActivated) return Vector3.zero;

        return (m_MarkerObj.transform.position - m_Obj.transform.position) / m_MaxDistance;
    }

    public override void ProcessJoystickActivation(Vector3 pinchPos)
    {
        Vector3 vec = pinchPos - m_Obj.transform.position;
        vec.y = 0f;

        float mag = vec.magnitude;
        if(mag >= m_MaxDistance)
        {
            vec = vec.normalized * m_MaxDistance;
        }

        Vector3 markerPos = m_Obj.transform.position + vec;
        m_MarkerObj.transform.position = markerPos;
    }
}

[Serializable]
public class VerticalJoystick : Joystick
{
    [SerializeField] private float m_MaxDistance = 0.05f;

    public override Vector3 GetAxis()
    {
        if (!IsActivated) return Vector3.zero;

        return (m_MarkerObj.transform.position - m_Obj.transform.position) / m_MaxDistance;
    }

    public override void ProcessJoystickActivation(Vector3 pinchPos)
    {
        //position marker obj   
        Vector3 vec = pinchPos - m_Obj.transform.position;
        vec.x = 0f;
        vec.z = 0f;

        float mag = vec.magnitude;
        if(mag >= m_MaxDistance)
        {
            vec = vec.normalized * m_MaxDistance;
        }

        Vector3 markerPos = m_Obj.transform.position + vec;
        m_MarkerObj.transform.position = markerPos;
    }
}

