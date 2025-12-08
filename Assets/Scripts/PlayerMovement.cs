using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;

    public float moveSpeed = 6f;
    Vector2 moveInput;
    Vector3 movement;

    private Vector3 startPosition;

    public float jumpForce = 2f;
    public float gravity = -9.81f;
    float verticalVelocity;

    public float rotationSpeed = 10f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        if (move.magnitude > 0.1f)
        {
            Vector3 targetDir = move.normalized;
            transform.forward = Vector3.Slerp(transform.forward, targetDir, rotationSpeed * Time.deltaTime);
        }

        if (characterController.isGrounded)
        {
            if (verticalVelocity < 0)
                verticalVelocity = -1f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        move.y = verticalVelocity;

        characterController.Move(move * moveSpeed * Time.deltaTime);
    }
    public void ResetPos() {
        characterController.enabled = false;
        transform.position = new Vector3(1, 1, 1);
        transform.forward = new Vector3(0, 0, 0);
        characterController.enabled = true;
        Debug.Log(startPosition);
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {
        if (characterController.isGrounded)
        {
            verticalVelocity = jumpForce;
        }
    }
}
