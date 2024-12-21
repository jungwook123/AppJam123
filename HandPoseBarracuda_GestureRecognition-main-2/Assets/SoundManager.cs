using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioClip bgmClip;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        PlayBGM();
    }

    public void PlayBGM()
    {
    bgmSource.clip = bgmClip;
    bgmSource.loop = true;
    bgmSource.Play();
    }
}
