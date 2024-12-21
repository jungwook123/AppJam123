using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource; // ȿ���� ���� AudioSource
    [SerializeField] private AudioClip[] bgmClips;
    [SerializeField] private AudioClip clickSound; // ��ư Ŭ�� ����
    [SerializeField] private AudioClip gameOverSound; // ���� ���� ����
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

        if (currentScene >= 3)
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
            Debug.LogWarning("BGM Ŭ���� �������� �ʾҽ��ϴ�.");
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
        if (gameOverSound != null && !sfxSource.isPlaying) // �ߺ� ��� ����
        {
            sfxSource.PlayOneShot(gameOverSound);
        }
    }
}
