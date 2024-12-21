using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float rotateAngle = 50;

    [SerializeField]
    private Text moveDir;
    

    void Start()
    {
    }

    void Update()
    {
        if(GameManager.Instance.isGameClear || GameManager.Instance.isGameOver || GameManager.Instance.isTimeOver) return;

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


    void OnCollisionEnter2D(Collision2D coll) 
    {
        IContact contact = coll.gameObject.GetComponent<IContact>();

        if(contact != null)
        {
            contact.Contact();
        }
    }

}
