using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    #region Variables
    public float jumpForce = 20f;
    public float fallVelocityMultiplier = 2.5f;
    public float lowJumpVelocityMultiplier = 2f;

    Rigidbody rb;
    bool shouldJump = false;
    bool jumpButtonDown = false;
    bool isGrounded = true;
    Vector3 fallGravity;
    Vector3 lowJumpGravity;

    const string JumpButtonName = "Jump";
    #endregion


    void Awake() {
        rb = GetComponent<Rigidbody>();
        fallGravity = (fallVelocityMultiplier - 1) * Physics.gravity;
        lowJumpGravity = (lowJumpVelocityMultiplier - 1) * Physics.gravity;
    }

    void Update() {
        if (Input.GetButtonDown(JumpButtonName) && isGrounded && GameController.IsPlaying) {
            shouldJump = true;
        }
        jumpButtonDown = Input.GetButton(JumpButtonName);
    }

    void FixedUpdate() {
        if (shouldJump) {
            Jump();
            shouldJump = false;
        }
        if (rb.velocity.y < 0) {
            ApplyFallGravity();
        } else if (rb.velocity.y > 0 && !jumpButtonDown) {
            ApplyLowJumpGravity();
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    void Jump() {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        isGrounded = false;
    }

    void ApplyFallGravity() {
        rb.velocity += Vector3.up * (fallGravity.y * Time.fixedDeltaTime);
    }

    void ApplyLowJumpGravity() {
        rb.velocity += Vector3.up * (lowJumpGravity.y * Time.fixedDeltaTime);
    }
}
