using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public Button[] buttons;
    public int curStage = 1;

    private void Start()
    {
        SetButtonName();
        SetButtonOpacity();
    }

    public void SetButtonName()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Text buttonText = buttons[i].GetComponentInChildren<Text>();

            buttonText.text = (i + 1).ToString();
        }
    }

    public void SetButtonOpacity()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Image buttonImage = buttons[i].GetComponent<Image>();

            Color color = buttonImage.color;
            if (i < curStage)
            {
                buttons[i].interactable = true;
                color.a = 1.0f;
                buttonImage.color = color;
            }
            else
            {
                color.a = 0.2f;
                buttons[i].interactable = false;
            }

            Text buttonText = buttons[i].GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                Color textColor = buttonText.color;

                if (i < curStage)
                {
                    textColor.a = 1.0f;
                }
                else
                {
                    textColor.a = 0.2f;
                }

                buttonText.color = textColor;
            }
        }
    }
}
