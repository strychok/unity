using UnityEngine;
using UnityEngine.InputSystem;


//[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;


    public float moveSpeed = 6f;
    Vector2 moveInput;
    Vector3 movement;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);
        characterController.Move(movement * moveSpeed * Time.deltaTime);

    }
    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
        
    }

}
