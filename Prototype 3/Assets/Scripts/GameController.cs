using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameSpeed))]
public class GameController : MonoBehaviour
{
    #region Variables
    public enum GameMode {Pregame, Playing, Gameover};
    public static GameMode CurrGameMode;
    public Spawner obstaclesSpawner;
    public Rigidbody playerRb;
    public AudioClip ingameMusic;
    
    GameSpeed gameSpeed;
    AudioSource audioSource;
    #endregion

    void Awake() {
        audioSource = GetComponent<AudioSource>();
        gameSpeed = GetComponent<GameSpeed>();
    }

    void Start() {
        CurrGameMode = GameMode.Pregame;
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown(Consts.JumpButtonName)) {
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
        GameSpeed.CurrentGameSpeed = gameSpeed.startingSpeed;
        CurrGameMode = GameMode.Playing;
        playerRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        audioSource.clip = ingameMusic;
        audioSource.Play();
    }
    
    public static void EndGame() {
        GameSpeed.CurrentGameSpeed = 0;
        CurrGameMode = GameMode.Gameover;
    }

    void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static bool IsPlaying => CurrGameMode == GameMode.Playing;
}
