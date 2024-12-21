using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour, IContact
{
    public void Contact()
    {
        GameManager.Instance.isGameClear = true;
        StageManager.Instance.CuStage += 1;
        MySceneManager.Instance.ChangeScene("Stage");
    }
}
