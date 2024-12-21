using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private Transform firstCanvas;
    [SerializeField]
    private Transform secondCanvas;
    public void ChangeScene()
    {
        MySceneManager.Instance.ChangeScene("Start");
    }

    public void ChangeScreen()
    {
        firstCanvas.gameObject.SetActive(false);
        secondCanvas.gameObject.SetActive(true);
    }
}
