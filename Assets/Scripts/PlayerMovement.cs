using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 10;
    public float jumpForce = 5;
    public float raycastDistance = 1.1F;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate() {
        float translation = Input.GetAxis("Vertical") * moveSpeed;
        float straffe = Input.GetAxis("Horizontal") * moveSpeed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        rb.MovePosition(transform.position + (transform.forward * translation * moveSpeed) + (transform.right * straffe * moveSpeed));
        // transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    private bool IsGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance);
    }
}