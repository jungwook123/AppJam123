using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerUI;
    [SerializeField]
    private float time;

    void Update()
    {
        if(GameManager.Instance.isTimeOver) return;

        time -= Time.deltaTime;

        timerUI.text = Minute() + ":" + Second();

        TimeOver();
    }

    string Minute()
    {
        float minute = time / 60f;

        if(minute < 10f)
        {
            return "0" + ((int)minute).ToString();
        }

        return ((int)minute).ToString();
    }

    string Second()
    {
        float second = time % 60f;
        
        if(second < 10f)
        {
            return "0" + ((int)second).ToString();
        }

        return ((int)second).ToString();
    }

    void TimeOver()
    {
        if(time <= 0)
        {
            GameManager.Instance.isTimeOver = true;
        }
    }
}
