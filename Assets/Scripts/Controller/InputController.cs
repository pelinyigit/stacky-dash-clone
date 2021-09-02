using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance { set; get; }

    [HideInInspector]
    public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;

    [HideInInspector]
    public Vector2 swipeDelta, startTouchPosition;
    private const float swipeZone = 100;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        tap = swipeLeft = swipeRight = swipeDown = swipeUp = false;

        #region Mobile Controllers
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            startTouchPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startTouchPosition = swipeDelta = Vector2.zero;
        }
        #endregion

        if (startTouchPosition != Vector2.zero)
        {
            if(Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouchPosition;
            }
        }

        if (swipeDelta.magnitude > swipeZone)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }
            else
            {
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }
            }
        }
    }
}
