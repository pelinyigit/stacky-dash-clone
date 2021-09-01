using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    //private bool isMoving = false;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(InputController.Instance.swipeLeft)
        {
            rb.velocity = Vector3.left * speed * Time.deltaTime;
        }
        else if (InputController.Instance.swipeRight)
        {
            rb.velocity = Vector3.right * speed * Time.deltaTime;
        }
        else if (InputController.Instance.swipeUp)
        {
            rb.velocity = Vector3.forward * speed * Time.deltaTime;
        }
        else if (InputController.Instance.swipeDown)
        {
            rb.velocity = -Vector3.forward * speed * Time.deltaTime;
        }
    }
}
