using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public CinemachineCamera cameraOne;
    public CinemachineCamera cameraTwo;
    public CinemachineCamera cameraThree;
    public CinemachineCamera cameraKey;

    IEnumerator Review() {
        yield return new WaitForSeconds(3f);
        cameraKey.Priority = 0;
    }
    void Start()
    {
        
    }


    public void ResetPriority() {
        cameraOne.Priority = 1;
        cameraTwo.Priority = 0;
        cameraThree.Priority = 0;
    }

    public void KeyRev() {
        cameraKey.Priority = 20;
        StartCoroutine(Review());

    }
}
