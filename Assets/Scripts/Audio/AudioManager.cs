using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("AUDIO SOURCE")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("BACKGROUND MUSIC")]
    public AudioClip backgroundMusic;

    [Header("AUDIO CLIPS")]
    public AudioClip[] audioClips;

    /*public AudioClip BackgroundMusic;
    public AudioClip buttons;*/
    void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip audio)
    {
        SFXSource.PlayOneShot(audio);
    }
}
