using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour, IContact
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float rotateAngle = 50;
    [SerializeField]
    private GameObject GameOverUI;

    void Start()
    {
        GameOverUI.SetActive(false);
    }

    void Update()
    {
        Move();
        if(Input.GetKey(KeyCode.A))
        {
            Rotate(1f);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            Rotate(-1f);
        }
    }

    void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * speed * Time.deltaTime;
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
