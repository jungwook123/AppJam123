using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void Retry()
    {
        MySceneManager.Instance.ChangeScene("TestAnimator");
    }

    public void Exit()
    {
        MySceneManager.Instance.ChangeScene("Stage");
    }
}
