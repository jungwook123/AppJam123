using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageOnOff : MonoBehaviour
{
    public Button[] buttons;

    
    void Start()
    {
        buttons = transform.GetComponentsInChildren<Button>();
        OnStageButton();
    }
    void OnStageButton()
    {
        for (int i = 0; i < StageManager.Instance.CuStage; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void LoadScene(string sceneName)
    {
        MySceneManager.Instance.ChangeScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
