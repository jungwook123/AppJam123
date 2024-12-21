using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager Instance;

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (fadeImage != null)
        {
            fadeImage.gameObject.SetActive(true);
            fadeImage.color = Color.black;
            FadeIn();
        }
    }

    public void ChangeScene(string sceneName)
    {
        print("1");
        if (fadeImage != null)
        {
            fadeImage.DOFade(1f, fadeDuration).OnComplete(() =>
            {
                SceneManager.LoadScene(sceneName);
                FadeIn();
            });
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private void FadeIn()
    {
        if (fadeImage != null)
        {
            fadeImage.DOFade(0f, fadeDuration).SetDelay(0.1f);
        }
    }
}