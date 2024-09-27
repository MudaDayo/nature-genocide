using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Player : MonoBehaviour
{
    private Vector2 movementInput;
    private bool attacking;
    private bool jumping;

    private float gravity = 9.81f;

    public float camYrotation;

    [SerializeField]
    private CharacterController controller;

    public Camera mainCam;

    [SerializeField]
    private float playerSpeed;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        controller.Move(new Vector3(0f, -gravity * Time.deltaTime, 0f));

        float forwardX = Camera.main.transform.forward.x;
        float forwardZ = Camera.main.transform.forward.z;

        float rightX = Camera.main.transform.right.x;
        float rightZ = Camera.main.transform.right.z;
        float totalX = forwardX * movementInput.y + rightX * movementInput.x;
        float totalZ = forwardZ * movementInput.y + rightZ * movementInput.x;

        Vector3 movementVector = new Vector3(totalX * Time.deltaTime, 0f, totalZ * Time.deltaTime);

        controller.Move(movementVector.normalized * playerSpeed * Time.deltaTime);
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

