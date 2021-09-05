using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedDashController : MonoBehaviour
{
    public void IncreaseDash()
    {
        EventManager.OnDashCollected?.Invoke();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dash")
        {
            IncreaseDash();
        }
    }
}
