using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public CinemachineCamera cameraOne;
    public CinemachineCamera cameraTwo;

    void Start()
    {
        
    }


    public void ResetPriority() {
        cameraOne.Priority = 1;
        cameraTwo.Priority = 0;
    }
}
