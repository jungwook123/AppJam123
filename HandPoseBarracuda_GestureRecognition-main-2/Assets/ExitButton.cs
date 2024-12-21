using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public void Retry()
    {
        
        MySceneManager.Instance.ChangeScene(SceneManager.GetActiveScene().name);
        gameObject.SetActive(false);
    }

    public void Exit()
    {
        MySceneManager.Instance.ChangeScene("Stage");
        gameObject.SetActive(false);
    }
}
