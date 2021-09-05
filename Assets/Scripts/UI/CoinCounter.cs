using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public ResourcesCoin resourcesCoin;

    public int collectedCoin;

    public static CoinCounter instance;

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
        EventManager.OnCoinCollected.AddListener(CoinCollected);
    }

    private void OnDisable()
    {
        EventManager.OnCoinCollected.RemoveListener(CoinCollected);
    }

    public void CoinCollected()
    {
        int i = 5;
        i += Random.Range(0, 2);
        resourcesCoin.coinAmount += i;
        collectedCoin += i;
    }

  
}
