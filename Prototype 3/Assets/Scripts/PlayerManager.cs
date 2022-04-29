using UnityEngine;

[RequireComponent(typeof(JumpController), typeof(AnimationController), typeof(ParticlesController)),
 RequireComponent(typeof(SoundController))]
public class PlayerManager : MonoBehaviour
{
    #region Variables
    bool shouldJump;
    bool isGrounded;
    JumpController jumpController;
    AnimationController animations;
    ParticlesController particles;
    SoundController sounds;
    #endregion


    void Awake() {
        shouldJump = false;
        isGrounded = true;
        jumpController = GetComponent<JumpController>();
        animations = GetComponent<AnimationController>();
        particles = GetComponent<ParticlesController>();
        sounds = GetComponent<SoundController>();
    }

    void Update() {
        if (Input.GetButtonDown(Consts.JumpButtonName) && isGrounded && GameController.IsPlaying) {
            shouldJump = true;
        }
    }

    void FixedUpdate() {
        if (shouldJump) {
            jumpController.Jump();
            isGrounded = false;
            particles.StopRunParticles();
            animations.PlayJumpAnimation();
            sounds.PlayJumpSound();
            shouldJump = false;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag(Consts.GroundTag)) {
            isGrounded = true;
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
