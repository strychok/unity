using UnityEngine;

public class TempDoor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void RotateD()
    {
        transform.Rotate(new Vector3(0f, 90f, 0f));   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
