using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static Action onCollisionWall;

    public static UnityEvent OnCurrentLevel = new UnityEvent();
    public static UnityEvent OnNextLevel = new UnityEvent();

    public static UnityEvent OnFinished = new UnityEvent();
    public static UnityEvent OnGameStarted = new UnityEvent();
    public static UnityEvent OnGamePaused = new UnityEvent();

    public static UnityEvent OnCoinCollected = new UnityEvent();
    public static UnityEvent OnDashCollected = new UnityEvent();
    public static UnityEvent OnDashRemoved = new UnityEvent();
    public static UnityEvent OnDashDropped = new UnityEvent();
}
