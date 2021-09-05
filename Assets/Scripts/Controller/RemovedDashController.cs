using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovedDashController : MonoBehaviour
{
    public void DecreaseDash()
    {
        EventManager.OnDashRemoved?.Invoke();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DropDash")
        {
            DecreaseDash();
        }
    }
}
