using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    #region Variables
    public float jumpForce = 20f;
    public float fallVelocityMultiplier = 2.5f;
    public float lowJumpVelocityMultiplier = 2f;
    public ParticleSystem runParticles;

    Rigidbody rb;
    Animator animator;
    bool shouldJump;
    bool isJumpButtonDown;
    bool isGrounded;
    Vector3 fallGravity;
    Vector3 lowJumpGravity;

    const string JumpButtonName = "Jump";
    #endregion


    void Awake() {
        shouldJump = false;
        isJumpButtonDown = false;
        isGrounded = true;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        fallGravity = (fallVelocityMultiplier - 1) * Physics.gravity;
        lowJumpGravity = (lowJumpVelocityMultiplier - 1) * Physics.gravity;
    }

    void Update() {
        if (Input.GetButtonDown(JumpButtonName)) {
            if (isGrounded && GameController.IsPlaying) {    
                shouldJump = true;
                animator.SetTrigger("Jump_trig");
            } else if (GameController.CurrGameMode == GameController.GameMode.Pregame) {  // game is starting
                runParticles.Play();
            }
        }
        isJumpButtonDown = Input.GetButton(JumpButtonName);
        animator.SetFloat("Speed_f", GameSpeed.CurrentGameSpeed);
    }

    void FixedUpdate() {
        if (shouldJump) {
            Jump();
            shouldJump = false;
        }
        if (rb.velocity.y < 0) {
            ApplyFallGravity();
        } else if (rb.velocity.y > 0 && !isJumpButtonDown) {
            ApplyLowJumpGravity();
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Ground")) {
            OnGround();
        }
    }

    void Jump() {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        OffGround();
    }

    void ApplyFallGravity() {
        rb.velocity += Vector3.up * (fallGravity.y * Time.fixedDeltaTime);
    }

    void ApplyLowJumpGravity() {
        rb.velocity += Vector3.up * (lowJumpGravity.y * Time.fixedDeltaTime);
    }

    void OnGround() {
        isGrounded = true;
        if (GameController.IsPlaying) {
            runParticles.Play();
        }
    }

    void OffGround() {
        isGrounded = false;
        runParticles.Stop();
    }
}
