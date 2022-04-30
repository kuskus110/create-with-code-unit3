using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    #region Variables
    TextMeshProUGUI scoreText;
    #endregion

    void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void LateUpdate()
    {
        scoreText.text = GameScore.CurrentGameScore.ToString();
    }
}
