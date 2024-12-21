using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IContact
{

    
    public void Contact()
    {
        GameManager.Instance.isGameOver = true;
        SoundManager.Instance.PlayGameOverSound();
    }
}
