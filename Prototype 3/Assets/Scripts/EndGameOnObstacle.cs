using UnityEngine;

public class EndGameOnObstacle : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Obstacle")) {
            GameController.EndGame();
        }
    }
}
