using UnityEngine;

public class AnimationController : MonoBehaviour
{
    #region Variables
    Animator animator;

    const string JumpTrigger = "Jump_trig";
    const string SprintSpeedMultiplier = "SprintSpeedMultiplier_f";
    const string SpeedParam = "Speed_f";
    const string DeathParam = "Death_b";
    #endregion

    void Awake()
    {
       animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        animator.SetFloat(SpeedParam, GameSpeed.CurrentGameSpeed);
    }

    public void PlayJumpAnimation() {
        animator.SetTrigger(JumpTrigger);
    }

    public void PlayDeathAnimation() {
        animator.SetBool(DeathParam, true);
    }

    public void PlaySprintAnimation(float sprintSpeedMultiplier) {
        animator.SetFloat(SprintSpeedMultiplier, sprintSpeedMultiplier);
    }

    public void StopSprintAnimation() {
        animator.SetFloat(SprintSpeedMultiplier, 1);
    }

    void OnAnimatorMove()
    {
        var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsTag("Walk Entry")) {
            Vector3 pos = transform.position;
            Vector3 endPos = pos;
            endPos.x += 5;
            transform.position = Vector3.Lerp(pos, endPos, Time.deltaTime);
            // animator.ApplyBuiltinRootMotion();  // this didn't work so I handled the motion manually
        }
    }
}
