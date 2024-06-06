using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton instance
    [SerializeField]
    private AudioSource resultSource;   // AudioSource for sound effects
    [SerializeField]
    private AudioSource BGSource;
    [SerializeField]
    private AudioClip winSound;
    [SerializeField]
    private AudioClip loseSound;

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void ResultPlayWinSound() {
        resultSource.PlayOneShot(winSound);
    }

    public void ResultPlayLoseSound() {
        resultSource.PlayOneShot(loseSound);
    }

    public void StopBGMusic() {
        BGSource.volume = 0;
    }
}
