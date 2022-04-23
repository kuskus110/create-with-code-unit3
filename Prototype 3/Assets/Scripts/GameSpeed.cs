using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    #region Variables
    public static float CurrentGameSpeed {get; set;}
    public float startingSpeed = 20f;
    [Tooltip("Increase the game speed every second by this value")]
    public float accelerationOverTime = 1f;
    #endregion

    void Awake() {
        CurrentGameSpeed = startingSpeed;
    }

    void Update() {
        CurrentGameSpeed += accelerationOverTime * Time.deltaTime;
    }
}
