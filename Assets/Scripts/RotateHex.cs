using UnityEngine;
using System.Collections;

public class RotateHex : MonoBehaviour, IInteractable
{
    [SerializeField] HexCotroller hexController;
    [SerializeField] RotateHex chainedHex;
    [SerializeField] float baseRotation = 0f;
    [SerializeField] float finalRotation = 0f;
    public bool rotateFromOutside = false;

    public void Interact()
    {
        if (hexController.canRotate)
        {

            StartCoroutine(RotateOverTime(60f, 1.5f));
            if (chainedHex != null)
            {
                if (rotateFromOutside == false) {
                    
                    chainedHex.rotateFromOutside = true;
                    chainedHex.Interact();
                }
            }
            hexController.canRotate = false;
        }
        
    }

    private IEnumerator RotateOverTime(float angle, float time)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0f, 0f, angle);

        float t = 0f;
        while (t < time)
        {
            t += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t / time);
            yield return null;
            
        }
        hexController.canRotate = true;
        transform.rotation = endRotation;
        if (rotateFromOutside == false)
        {
            hexController.WinCheck();
        }
        rotateFromOutside = false;
        //Debug.Log(transform.rotation.z);
        
    }

    void Start() { 
        SetBaseRotation();
    }
    void Update()
    {
        
    }
    void SetBaseRotation() {
        transform.Rotate(0f, 0f, baseRotation);
    }
    public bool CheckRotation() {
        float angle = Quaternion.Angle(transform.rotation, Quaternion.Euler(0f, 0f, finalRotation));
        Debug.Log(angle <0.1f);
        return angle < 0.1f;
    }
}
