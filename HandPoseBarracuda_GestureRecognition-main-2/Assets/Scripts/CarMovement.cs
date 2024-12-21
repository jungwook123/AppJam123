using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotateAngle;

    void Start()
    {
        
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
}
