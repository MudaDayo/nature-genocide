using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private Vector2 movementInput;

    public float mouseSensitivity = 100f;
    //public Transform playerBody;
    float xRotation = 0f;
    float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = movementInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = movementInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        //playerBody.Rotate(Vector3.up * mouseX);
    }

    public void OnMoveCamera(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}