using UnityEngine;

public class GameScore : MonoBehaviour
{
    #region Variables
    public static int CurrentGameScore;
    #endregion

    void Awake()
    {
        CurrentGameScore = 0;
    }

    void Update()
    {
        CurrentGameScore += Mathf.CeilToInt(GameSpeed.CurrentGameSpeed * Time.deltaTime);
    }
}
