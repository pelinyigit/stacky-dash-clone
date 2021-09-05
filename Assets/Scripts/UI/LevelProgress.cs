using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    public GameObject player;
    private GameObject finish;

    private float playerStartPosition;
    private float playerPosition;
    private float finishPosition;

    public float totalDistance;
    public float currentDistance;

    public float progress;

    public Image fillImage;


    void Awake()
    {
        finish = GameObject.Find("Finish");
        playerStartPosition = player.transform.position.z;
        finishPosition = finish.transform.position.z;
        totalDistance = finishPosition - playerStartPosition;
        currentDistance = finishPosition - playerStartPosition;
    }


    void Update()
    {
        CheckProgress();
    }

    void CheckProgress()
    {
        playerPosition = player.transform.position.z;
        currentDistance = finishPosition - playerPosition;
        progress = (totalDistance - currentDistance) / totalDistance;
        fillImage.fillAmount = progress;
    }
}
