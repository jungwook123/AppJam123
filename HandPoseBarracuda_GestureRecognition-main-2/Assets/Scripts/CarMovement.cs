using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float rotateAngle = 50;

    void Start()
    {
    }

    void Update()
    {
        if(GameManager.Instance.isGameClear || GameManager.Instance.isGameOver || GameManager.Instance.isTimeOver) return;

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


    void OnCollisionEnter2D(Collision2D coll) 
    {
        IContact contact = coll.gameObject.GetComponent<IContact>();

        if(contact != null)
        {
            contact.Contact();
        }
    }
}
