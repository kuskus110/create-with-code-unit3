using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    #region Variables
    public static float CurrentGameSpeed;
    public float startingSpeed = 20f;
    [Tooltip("Increase the game speed every second by this value")]
    public float accelerationOverTime = 1f;
    #endregion

    void Update() {
        if (GameController.IsPlaying) {
            CurrentGameSpeed += accelerationOverTime * Time.deltaTime;
        }
    }
}
