using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    private Button[] buttons;

    void Start()
    {
        buttons = FindObjectsOfType<Button>();

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    private void OnButtonClick()
    {
        SoundManager.Instance.PlayClickSound();
    }

    void OnDestroy()
    {
        if (buttons != null)
        {
            foreach (Button button in buttons)
            {
                button.onClick.RemoveListener(OnButtonClick);
            }
        }
    }
}