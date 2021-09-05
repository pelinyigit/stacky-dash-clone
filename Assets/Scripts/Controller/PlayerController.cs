using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isMoving = false;
    int childSize = 0;
    public static PlayerController instance;
    public float speed;
    public GameObject dashesParent;
    public GameObject dropDashesParent;
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
        EventManager.OnDashDropped.AddListener(DropDashes);
    }

    private void OnDisable()
    {
        EventManager.onCollisionWall -= WallCollision;
        EventManager.OnDashDropped.RemoveListener(DropDashes);
    }

    private void WallCollision()
    {
        rb.velocity = Vector3.zero;
    }
    
    public void StartScene()
    {
       
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.instance.currentState == GameManager.GameState.DefaultGameState)
        {
            EventManager.OnGameStarted?.Invoke();
        }
    }

    void FixedUpdate()
    {
        if (GameManager.instance.currentState == GameManager.GameState.StartGameState)
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

    public void DropDashes()
    {
       

        for (int i = 0; i < dashesParent.transform.childCount; i++)
        {
            childSize = i;
        }

        Debug.Log(childSize);
        Destroy(dashesParent.transform.GetChild(childSize).gameObject);
        
        

        Vector3 characterPosition = transform.position;
        characterPosition.y -= 0.047f;
        transform.position = characterPosition;



       // prevDash.GetComponent<BoxCollider>().isTrigger = true;
    }
}
