using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public void IncreaseCoin()
    {
        EventManager.OnCoinCollected?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dash")
        {
            IncreaseCoin();
        }
    }
}
