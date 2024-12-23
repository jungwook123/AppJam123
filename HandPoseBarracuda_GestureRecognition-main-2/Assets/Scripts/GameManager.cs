using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector]
    public bool isTimeOver = false;
    [HideInInspector]
    public bool isGameOver = false;
    [HideInInspector]
    public bool isGameClear = false;

    [SerializeField]
    private GameObject GameOverUI;
    [SerializeField]
    private GameObject TimeOverUI;
    [SerializeField]
    private GameObject GameClearUI;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        //SceneManager.sceneLoaded += Init;
    }
    
    void OnDisable()
    {
        SceneManager.sceneLoaded -= Init;
    }

    void Update()
    {
        if(isTimeOver)
        {
            isTimeOver = false;
            TimeOverUI.SetActive(true);
            
        }
        if(isGameOver)
        {
            isGameOver = false;
            GameOverUI.SetActive(true);
        }
        if(isGameClear)
        {
            isGameClear = false;
            StartCoroutine("GameClear");
            
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            MySceneManager.Instance.ChangeScene("Stage5");
        }
    }

    public void Init(Scene scene, LoadSceneMode mode)
    {
        isTimeOver = false;
        isGameOver = false;
        isGameClear = false;
        TimeOverUI.SetActive(false);
        GameOverUI.SetActive(false);
        GameClearUI.SetActive(false);
    }

    IEnumerator GameClear()
    {
        yield return new WaitForSeconds(1f);
        GameClearUI.SetActive(false);
    }
}
