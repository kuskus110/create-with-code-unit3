using UnityEngine;

public class SoundController : MonoBehaviour
{
    #region Variables
    public AudioClip jumpSound;
    public AudioClip crashSound;

    AudioSource audioSource;
    #endregion

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJumpSound() {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayCrashSound() {
        audioSource.PlayOneShot(crashSound);
    }
}
