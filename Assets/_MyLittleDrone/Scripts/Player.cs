using Oculus.Interaction;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            if(Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
        }
    }

    public HandVisual m_HandVisual_L;
    public HandVisual m_HandVisual_R;
    
    public Vector3 GetPinchPos_L()
    {
        Transform indexTr = m_HandVisual_L.GetTransformByHandJointId(Oculus.Interaction.Input.HandJointId.HandIndexTip);
        Transform thumbTr = m_HandVisual_L.GetTransformByHandJointId(Oculus.Interaction.Input.HandJointId.HandThumbTip);

        return Vector3.Lerp(indexTr.position, thumbTr.position, 0.5f);
    }

    public Vector3 GetPinchPos_R()
    {
        Transform indexTr = m_HandVisual_R.GetTransformByHandJointId(Oculus.Interaction.Input.HandJointId.HandIndexTip);
        Transform thumbTr = m_HandVisual_R.GetTransformByHandJointId(Oculus.Interaction.Input.HandJointId.HandThumbTip) ;

        return Vector3.Lerp(indexTr.position, thumbTr.position, 0.5f);
    }
}
