using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isMoving = false;

    public static PlayerController instance;
    public float speed;
    public GameObject dashesParent;
    public GameObject prevDash;
    public GameObject defaultCanvas; 

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        EventManager.onCollisionWall += WallCollision;
    }

    private void OnDisable()
    {
        EventManager.onCollisionWall -= WallCollision;
    }

    private void WallCollision()
    {
        rb.velocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        if (InputController.Instance.swipeLeft && !isMoving)
        {
            defaultCanvas.SetActive(false);
            isMoving = true;
            rb.velocity = Vector3.left * speed * Time.deltaTime;
        }
        else if (InputController.Instance.swipeRight && !isMoving)
        {
            defaultCanvas.SetActive(false);
            isMoving = true;
            rb.velocity = Vector3.right * speed * Time.deltaTime;
        }
        else if (InputController.Instance.swipeUp && !isMoving)
        {
            defaultCanvas.SetActive(false);
            isMoving = true;
            rb.velocity = Vector3.forward * speed * Time.deltaTime;
        }
        else if (InputController.Instance.swipeDown && !isMoving)
        {
            defaultCanvas.SetActive(false);
            isMoving = true;
            rb.velocity = -Vector3.forward * speed * Time.deltaTime;
        }
        if (rb.velocity == Vector3.zero)
        {
            isMoving = false;
        }
    }

    public void TakeDashes(GameObject dash)
    {
        dash.transform.SetParent(dashesParent.transform);
        Vector3 pos = prevDash.transform.localPosition;
        pos.y -= 0.047f;
        dash.transform.localPosition = pos;

        Vector3 characterPosition = transform.localPosition;
        characterPosition.y += 0.047f;
        transform.localPosition = characterPosition;
        prevDash = dash;

        prevDash.GetComponent<BoxCollider>().isTrigger = false;
    }
}
