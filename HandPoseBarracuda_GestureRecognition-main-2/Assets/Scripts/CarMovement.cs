using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour, IContact
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float rotateAngle = 50;
    [SerializeField]
    private GameObject GameOverUI;

    [SerializeField]
    private Text moveDir;
    

    void Start()
    {
        GameOverUI.SetActive(false);
    }

    void Update()
    {
        Move();
        if(moveDir.text == "왼쪽 돌기")
        {
            Rotate(1f);
        }
        else if(moveDir.text == "오른쪽 돌기")
        {
            Rotate(-1f);
        }
    }

    void Move()
    {
        if(moveDir.text == "움직임")
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.up * speed * Time.deltaTime;
        }
    }

    void Rotate(float dir)
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + dir * rotateAngle * Time.deltaTime);
    }

    public void Contact()
    {
        GameOverUI.SetActive(true);
    }

}
