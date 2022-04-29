using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    #region Variables
    public ParticleSystem runParticles;
    public ParticleSystem explosion;
    #endregion

    void Update()
    {
        if (Input.GetButtonDown(Consts.JumpButtonName) && GameController.CurrGameMode == GameController.GameMode.Pregame) {
                PlayRunParticles();
            }
    }

    public void PlayRunParticles() {
        runParticles.Play();
    }

    public void StopRunParticles() {
        runParticles.Stop();
    }

    public void PlayExplosion() {
        explosion.Play();
    }
}
