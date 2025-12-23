using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Close() {
        animator.SetBool("open", false);
    }
    public void Open() {
        animator.SetBool("open", true);
    }

}
