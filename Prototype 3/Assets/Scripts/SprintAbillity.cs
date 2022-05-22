using UnityEngine;

[RequireComponent(typeof(AnimationController))]
public class SprintAbillity : MonoBehaviour
{
    #region Variables
    public float gameSpeedMultiplier = 1.75f;
    public float animationSpeedMultiplier = 3f;

    bool isSprinting;
    AnimationController animations;
    #endregion

    void Awake()
    {
        isSprinting = false;
        animations = GetComponent<AnimationController>();
    }

    void Update()
    {
        if (Input.GetButtonDown(Consts.SprintButtonName) && PlayerManager.playerState == PlayerManager.State.Running && GameController.IsPlaying) {
            StartSprint();
        }
        else if (Input.GetButtonUp(Consts.SprintButtonName) || (PlayerManager.playerState != PlayerManager.State.Running && isSprinting)) {
            StopSprint();
        }
    }

    void OnCollisionEnter(Collision other) {
        // Continue sprint after landing if sprint button is down:
        if (other.gameObject.CompareTag(Consts.GroundTag) && Input.GetButton(Consts.SprintButtonName) && GameController.IsPlaying) {
            StartSprint();
        }
    }

    private void StartSprint()
    {
        isSprinting = true;
        GameSpeed.CurrentGameSpeed *= gameSpeedMultiplier;
        animations.PlaySprintAnimation(animationSpeedMultiplier);
    }

    private void StopSprint()
    {
        isSprinting = false;
        GameSpeed.CurrentGameSpeed /= gameSpeedMultiplier;
        animations.StopSprintAnimation();
    }

}
