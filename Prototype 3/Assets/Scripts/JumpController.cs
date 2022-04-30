using UnityEngine;

[RequireComponent((typeof(Rigidbody)))]
public class JumpController : MonoBehaviour
{
    #region Variables
    public int allowedAirJumps = 1;
    public float jumpForce = 20f;
    public float fallVelocityMultiplier = 2.5f;
    public float lowJumpVelocityMultiplier = 2f;

    Rigidbody rb;
    bool isJumpButtonDown;
    Vector3 fallGravity;
    Vector3 lowJumpGravity;

    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isJumpButtonDown = false;
        fallGravity = (fallVelocityMultiplier - 1) * Physics.gravity;
        lowJumpGravity = (lowJumpVelocityMultiplier - 1) * Physics.gravity;
    }

    void Update() {
        isJumpButtonDown = Input.GetButton(Consts.JumpButtonName);
    }

    void FixedUpdate()
    {
        if (rb.velocity.y < 0) {
            ApplyFallGravity();
        } else if (rb.velocity.y > 0 && !isJumpButtonDown) {
            ApplyLowJumpGravity();
        }
    }

    public void Jump() {
        // rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        rb.velocity = Vector3.up * jumpForce;
    }
    
    void ApplyFallGravity() {
        rb.velocity += Vector3.up * (fallGravity.y * Time.fixedDeltaTime);
    }

    void ApplyLowJumpGravity() {
        rb.velocity += Vector3.up * (lowJumpGravity.y * Time.fixedDeltaTime);
    }
}
