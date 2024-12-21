using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private Transform firstCanvas;
    [SerializeField]
    private Transform secondCanvas;
    public void ChangeScene(string scene)
    {
        MySceneManager.Instance.ChangeScene(scene);
    }

    public void ChangeScreen()
    {
        firstCanvas.gameObject.SetActive(false);
        secondCanvas.gameObject.SetActive(true);
    }
}
