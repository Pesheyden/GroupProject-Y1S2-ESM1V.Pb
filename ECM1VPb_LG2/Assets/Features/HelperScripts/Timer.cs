using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    [Tooltip("Time since start")]
    public float ElapsedTime;
    public bool isTimerStarted = false;
    public bool isTimerDisplayed = false;

    private float targetTime;

    [Header("Event")][Space(20)]

    public UnityEvent TimeBasedEvent;

    private void Start()
    {
        if (TimeBasedEvent == null) 
        { 
            TimeBasedEvent = new UnityEvent(); 
        } 
    }

    private void Update() 
    {
        if (isTimerStarted)
            TriggerAfterTime();

        if (isTimerDisplayed)
            DisplayTimer();
    }

    public void StartTimer(float TargetTime)
    {

        isTimerStarted = true;
        targetTime = TargetTime;
    }

    public void DisplayTimer()
    {
        int Minutes = Mathf.FloorToInt(ElapsedTime / 60);
        int Seconds = Mathf.FloorToInt(ElapsedTime % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", Minutes, Seconds);
    }

    public void TriggerAfterTime()
    {
        ElapsedTime += Time.deltaTime;
        if (ElapsedTime >= targetTime && TimeBasedEvent != null)    
        {
            isTimerStarted = false;
            TimeBasedEvent.Invoke();
        }
    }
}
