using System;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [SerializeField] private HorizontalJoystick m_HorizontalJoystick;
    [SerializeField] private VerticalJoystick m_VerticalJoystick;

    private bool isPinching_L;
    private bool isPinching_R;

    /// <summary>
    /// ex) (1,0,1)... y = 0
    /// Scaled (0~1)
    /// </summary>
    public Vector3 HorizontalAxis => m_HorizontalJoystick.GetAxis();

    /// <summary>
    /// ex( 0,1,0)  x =0 , z= 0,
    /// /// Scaled (0~1)
    /// </summary>
    public Vector3 VerticalAxis => m_VerticalJoystick.GetAxis();

    void Start()
    {
        m_HorizontalJoystick.Init();
        m_VerticalJoystick.Init();
    }

    
    void Update()
    {
        CheckPinchAndActivateJoystick();
    }

    private void CheckPinchAndActivateJoystick()
    {
        //check pinch  && activate joystick
        if (Player.Instance.m_HandVisual_L.Hand.GetIndexFingerIsPinching())
        {
            if (!isPinching_L)
            {
                isPinching_L = true;
                OnPinch_L();
            }

            //marker obj follow pinchpos
            m_HorizontalJoystick.ProcessJoystickActivation(Player.Instance.GetPinchPos_L());
        }
        else
        {
            if (isPinching_L)
            {
                isPinching_L = false;
                OnPinchRelease_L();
            }
        }


        if (Player.Instance.m_HandVisual_R.Hand.GetIndexFingerIsPinching())
        {
            if (!isPinching_R)
            {
                isPinching_R = true;
                OnPinch_R();
            }

            //marker obj follow pinch pos
            m_VerticalJoystick.ProcessJoystickActivation(Player.Instance.GetPinchPos_R());
        }
        else
        {
            if (isPinching_R)
            {
                isPinching_R = false;
                OnPinchRelease_R();
            }
        }
    }
    private void OnPinch_L()
    {
        Vector3 pinchPos = Player.Instance.GetPinchPos_L();
        m_HorizontalJoystick.Show(pinchPos);
    }

    private void OnPinch_R()
    {
        Vector3 pinchPos = Player.Instance.GetPinchPos_R();
        m_VerticalJoystick.Show(pinchPos);
    }

    private void OnPinchRelease_L()
    {
        m_HorizontalJoystick.Hide();
    }

    private void OnPinchRelease_R()
    {
        m_VerticalJoystick.Hide();
    }



}
