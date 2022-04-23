using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameSpeed))]
public class GameController : MonoBehaviour
{
    #region Variables
    public enum GameMode {Pregame, Playing, Gameover};
    public static GameMode CurrGameMode;
    public Spawner obstaclesSpawner;
    
    GameSpeed gameSpeed;
    #endregion

    void Awake() {
        gameSpeed = GetComponent<GameSpeed>();
    }

    void Start() {
        CurrGameMode = GameMode.Pregame;
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Jump")) {
            switch (CurrGameMode) {
                case GameMode.Pregame:
                    StartGame();
                    break;
                case GameMode.Gameover:
                    ResetGame();
                    break;
            }
        }
    }

    void StartGame() {
        print("start");
        GameSpeed.CurrentGameSpeed = gameSpeed.startingSpeed;
        CurrGameMode = GameMode.Playing;
    }
    
    public static void EndGame() {
        print("end");
        GameSpeed.CurrentGameSpeed = 0;
        CurrGameMode = GameMode.Gameover;
    }

    void ResetGame() {
        print("reset");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static bool IsPlaying => CurrGameMode == GameMode.Playing;
}
