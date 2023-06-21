// Należy zaimportować Joystick Pack, następnie po dodaniu skryptu do postaci
// popodłączać wszystko w edytorze Unity.
// https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631#description

using UnityEngine;

public class TestJoystickMovement : MonoBehaviour {
    [SerializeField] float movementSpeed = 5f;     // Speed of movement
    [SerializeField] float rotationSpeed = 100f;   // Speed of rotation
    [SerializeField] float jumpSpeed = 5f;         // Speed of jump

    bool isGrounded = true;                        // Flag indicating if the character is on the ground

    [SerializeField] FixedJoystick _joystick;      // Reference to the joystick for movement

    Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        float horizontalJoystick = _joystick.Horizontal;     // Get horizontal input from the movement joystick
        float verticalJoystick = _joystick.Vertical;         // Get vertical input from the movement joystick

        Vector3 movement = new Vector3(horizontalJoystick, 0f, verticalJoystick) * movementSpeed * Time.deltaTime;
        // Calculate the movement vector based on joystick input and movement speed
        // Time.deltaTime is used to make the movement frame-rate independent
        rb.MovePosition(rb.position + transform.TransformDirection(movement));
        // Move the character's position by the calculated movement vector

        // Rotate the character based on joystick input
        float rotation = horizontalJoystick * rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotation);
        rb.MoveRotation(rb.rotation * deltaRotation);

    }

    public void Skocz() { // this function is directly hooked up with the button in the Unity editor
        if (isGrounded) { // This prevents the object from double-jumping
            // Apply an upward force to the character to make it jump
            rb.AddForce(new Vector3(0f, jumpSpeed), ForceMode.Impulse);
        }
        isGrounded = false;
}

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;  // Set isGrounded flag to true when the character collides with the ground
        }
    }
}

