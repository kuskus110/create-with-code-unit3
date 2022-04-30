using UnityEngine;

[RequireComponent(typeof(JumpController), typeof(AnimationController), typeof(ParticlesController)),
 RequireComponent(typeof(SoundController))]
public class PlayerManager : MonoBehaviour
{
    #region Variables
    public static bool IsGrounded;
    bool shouldJump;
    int maxAllowedJumps;
    int currJumpsCounter;
    JumpController jumpController;
    AnimationController animations;
    ParticlesController particles;
    SoundController sounds;
    #endregion


    void Awake() {
        IsGrounded = true;
        shouldJump = false;
        jumpController = GetComponent<JumpController>();
        maxAllowedJumps = jumpController.allowedAirJumps + 1;
        currJumpsCounter = 0;
        animations = GetComponent<AnimationController>();
        particles = GetComponent<ParticlesController>();
        sounds = GetComponent<SoundController>();
    }

    void Update() {
        if (Input.GetButtonDown(Consts.JumpButtonName) && currJumpsCounter < maxAllowedJumps && GameController.IsPlaying) {
            shouldJump = true;
        }
    }

    void FixedUpdate() {
        if (shouldJump) {
            jumpController.Jump();
            IsGrounded = false;
            currJumpsCounter += 1;
            particles.StopRunParticles();
            animations.PlayJumpAnimation();
            sounds.PlayJumpSound();
            shouldJump = false;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag(Consts.GroundTag)) {
            IsGrounded = true;
            currJumpsCounter = 0;
            if (GameController.IsPlaying) {
                particles.PlayRunParticles();
            }
        } else if (collision.collider.CompareTag(Consts.ObstacleTag)) {
            GameController.EndGame();
            animations.PlayDeathAnimation();
            sounds.PlayCrashSound();
            particles.PlayExplosion();
        }
    }
}
