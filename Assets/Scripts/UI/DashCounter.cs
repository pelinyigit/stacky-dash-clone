using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCounter : MonoBehaviour
{

    public int collectedDash = 1;

    public static DashCounter instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        EventManager.OnDashCollected.AddListener(DashCollected);
        EventManager.OnDashRemoved.AddListener(DashRemoved);
    }

    private void OnDisable()
    {
        EventManager.OnDashCollected.RemoveListener(DashCollected);
        EventManager.OnDashRemoved.RemoveListener(DashRemoved);
    }

    public void DashCollected()
    {
        int i = 1;
      //  i += Random.Range(0, 2);
        collectedDash += i;
    }

    public void DashRemoved()
    {
        collectedDash -= 1;
    }


}
