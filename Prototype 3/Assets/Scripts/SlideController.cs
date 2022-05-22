using UnityEngine;

public class SlideController : MonoBehaviour
{
    #region Variables
    public BoxCollider upperCollider;

    AnimationController animations;
    #endregion

    void Awake()
    {
        animations = GetComponent<AnimationController>();
    }

    public void StartSliding() {
        upperCollider.enabled = false;
        animations.PlaySlideAnimation();
    }

    public void StopSliding() {
        animations.StopSlideAnimation();
        upperCollider.enabled = true;
    }
}
