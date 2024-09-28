using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{
    private Vector2 movementInput;
    private bool attacking;
    private bool jumping;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float gravity;

    public float camYrotation;

    [SerializeField]
    private CharacterController controller;

    public Camera mainCam;

    [SerializeField]
    private float playerSpeed;


    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float forwardX = Camera.main.transform.forward.x;
        float forwardZ = Camera.main.transform.forward.z;

        float rightX = Camera.main.transform.right.x;
        float rightZ = Camera.main.transform.right.z;
        float totalX = forwardX * movementInput.y + rightX * movementInput.x;
        float totalZ = forwardZ * movementInput.y + rightZ * movementInput.x;


        Vector3 movementVector = new Vector3(totalX, -gravity, totalZ);

        if (jumping && controller.isGrounded)
        {
            movementVector += new Vector3(0f, jumpForce, 0f);
        }

        controller.Move(new Vector3(movementVector.x * playerSpeed * Time.deltaTime, movementVector.y * Time.deltaTime, movementVector.z * playerSpeed * Time.deltaTime));
    }



    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        attacking = context.action.triggered;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jumping = context.action.triggered;
    }
}

