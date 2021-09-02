using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialAnimation : MonoBehaviour
{
    public Animation swipeAnimation;
    public GameObject swipeToPlayPanel;

    void Start()
    {
        swipeAnimation = GetComponent<Animation>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swipeAnimation.Stop("Swipe");
            swipeToPlayPanel.SetActive(false);
        }
    }
}
