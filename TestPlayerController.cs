using UnityEngine;

public class TestPlayerController : MonoBehaviour {
    public float movementSpeed = 5f;
    public float rotationSpeed = 100f;
    public float predkoscSkoku = 5f;
    private bool jestNaZiemi = true;

    

    private Rigidbody rb;

    private void Awake() {
        
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Translate the character
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + transform.TransformDirection(movement));

        // Rotate the character
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotation);
        rb.MoveRotation(rb.rotation * deltaRotation);

        if (jestNaZiemi && Input.GetKeyDown(KeyCode.Space)) {
            Skocz();
        }
    }

    private void Skocz() {
        rb.AddForce(new Vector3(0f, predkoscSkoku), ForceMode.Impulse);
        jestNaZiemi = false;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            jestNaZiemi = true;
        }
    }
}
//"

/*
ChatGPT

In this script:

* The 'movementSpeed' variable determines the character's movement speed.
* The 'rotationSpeed' variable determines the character's rotation speed.
* The 'Awake' function gets the Rigidbody component attached to the character.
* The 'Update' function is called every frame to read input and update the character's movement and rotation.
* The 'Input.GetAxis' method is used to read the horizontal and vertical input axes.
* The character's movement is calculated using the input axes and multiplied by the movement speed. 
  The resulting movement vector is transformed into the character's local space using 'transform.TransformDirection' 
  and then added to the Rigidbody's position using 'rb.MovePosition'.
* The character's rotation is calculated based on the horizontal input and multiplied by the rotation speed. 
  The rotation is then applied to the Rigidbody using 'rb.MoveRotation'.

*/




