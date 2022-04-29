using UnityEngine;

public class HandleObstacleCollision : MonoBehaviour
{
    Animator animator;
    public ParticleSystem explosion;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Obstacle")) {
            GameController.EndGame();
            animator.SetBool("Death_b", true);
            explosion.Play();
        }
    }
}
