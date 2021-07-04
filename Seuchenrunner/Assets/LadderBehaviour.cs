using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderBehaviour : MonoBehaviour
{
    public float ClimbingSpeed;


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.W))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, ClimbingSpeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ClimbingSpeed);
            }
            else
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); 
            }

        }
    }
}
