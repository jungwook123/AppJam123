using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public Text[] stages;
    public Button[] buttons;
    int curStage = 1;

    private void Start()
    {
        for (int i = 0; i < stages.Length; i++)
        {
            // Set stage text based on stage index (you could change this to match your need)
            stages[i].text = "Stage " + (i + 1);
        }
    }

    public void SetButtonOpacity(float alpha)
    {
        // Loop through all the buttons
        for (int i = 0; i < buttons.Length; i++)
        {
            Image buttonImage = buttons[i].GetComponent<Image>();

            // Check if the current button is within the active stages
            if (i < curStage)
            {
                Color color = buttonImage.color;
                color.a = alpha;  // Set desired alpha value
                buttonImage.color = color;
            }
            else
            {
                // Set opacity to 0 for disabled buttons or any other logic
                Color color = buttonImage.color;
                color.a = 0.2f;
                buttonImage.color = color;
            }
        }
    }
}
