using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destination : MonoBehaviour, IContact
{
    public string text = "Stage";
    public void Contact()
    {
        GameManager.Instance.isGameClear = true;
        StageManager.Instance.CuStage += 1;
        MySceneManager.Instance.ChangeScene(text);
    }
}
