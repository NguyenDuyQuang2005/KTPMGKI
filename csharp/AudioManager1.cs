using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManaGer : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic; // Nguồn âm thanh nền
    [SerializeField] private AudioSource effectSound;
    [SerializeField] private AudioClip backgroundClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip coinClip;
    // Start is called before the first frame update
    void Start()
    {
        PlayBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayBackgroundMusic()
    {

        backgroundMusic.clip = backgroundClip;
        backgroundMusic.Play();

    }
    public void PlayJumpSound()
    {
        effectSound.PlayOneShot(jumpClip);
    }
    public void PlayCoinSound()
    {
        effectSound.PlayOneShot(coinClip);
    }
}
