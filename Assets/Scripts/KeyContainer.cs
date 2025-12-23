using UnityEngine;

public class KeyContainer : MonoBehaviour
{
    [SerializeField] Key Key;
    Animator Animator;
    [SerializeField] CameraController CameraController;
    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }
    public void Open() {
        CameraController.KeyRev(); 
        Animator.SetBool("open", true);
        Key.Activate();
    }
}
