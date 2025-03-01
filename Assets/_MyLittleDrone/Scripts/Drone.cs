using UnityEngine;

public class Drone : MonoBehaviour
{
    private JoystickController joystickController;

    [SerializeField] private float m_HorizontalMoveSpeed = 1.0f;
    [SerializeField] private float m_VerticalMoveSpeed = 1.0f;  
    void Start()
    {
        joystickController = FindAnyObjectByType<JoystickController>();
    }

    void Update()
    {
        MoveHorizontal();
        MoveVertical();
    }

    private void MoveHorizontal()
    {
        //horizontal axis
        Vector3 horizontalAxis = joystickController.HorizontalAxis;
        this.transform.position += horizontalAxis * Time.deltaTime * m_HorizontalMoveSpeed;

        //rotate 
        if(horizontalAxis != Vector3.zero )
        {
            this.transform.rotation = Quaternion.LookRotation(horizontalAxis.normalized);
        }
    }

    private void MoveVertical()
    {
        //vertical axis
        Vector3 verticalAxis = joystickController.VerticalAxis;
        this.transform.position += verticalAxis * Time.deltaTime * m_VerticalMoveSpeed; 
    }
}
