using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll) 
    {
        IContact contact = coll.gameObject.GetComponent<IContact>();

        if(contact != null)
        {
            contact.Contact();
        }
    }
}
