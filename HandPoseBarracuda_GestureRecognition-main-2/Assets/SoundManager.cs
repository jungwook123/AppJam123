using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource; // 효과음 전용 AudioSource
    [SerializeField] private AudioClip[] bgmClips;
    [SerializeField] private AudioClip clickSound; // 버튼 클릭 사운드
    [SerializeField] private AudioClip gameOverSound; // 게임 오버 사운드
    private int curBGM = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayBGM();
    }

    void Update()
    {
        CheckGameOverState();
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int currentScene = scene.buildIndex;

        if (currentScene >= 7)
        {
            curBGM = 1;
            bgmSource.volume = 1.0f;
        }
        else
        {
            curBGM = 0;
            bgmSource.volume = 0.5f;
        }

        PlayBGM();
    }

    public void PlayBGM()
    {
        if (curBGM < bgmClips.Length)
        {
            bgmSource.clip = bgmClips[curBGM];
            bgmSource.loop = true;
            bgmSource.Play();
        }
        else
        {
            Debug.LogWarning("BGM 클립이 설정되지 않았습니다.");
        }
    }

    public void PlayClickSound()
    {
        if (clickSound != null)
        {
            sfxSource.PlayOneShot(clickSound);
        }
    }

    private void CheckGameOverState()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
        {
            PlayGameOverSound();
        }
    }

    public void PlayGameOverSound()
    {
        if (gameOverSound != null && !sfxSource.isPlaying) // 중복 재생 방지
        {
            sfxSource.PlayOneShot(gameOverSound);
        }
    }
}