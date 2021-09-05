using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGameAnimation : MonoBehaviour
{
    public ParticleSystem confettiPs1;
    public ParticleSystem confettiPs2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            confettiPs1.Play();
            confettiPs2.Play();
           // EventManager.OnFinished?.Invoke();
        }
    }
}
