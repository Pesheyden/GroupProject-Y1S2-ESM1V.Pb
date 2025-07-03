using System;
using UnityEngine;

public class StopTimeController : MonoBehaviour
{
    [SerializeField] private bool _stopTimeOnAwake;
    [SerializeField] private bool _stopTimeOnEnable;
    [SerializeField] private bool _stopTimeOnStart;

    private void Awake()
    {
        if (_stopTimeOnAwake)
        {
            Time.timeScale = 0;
        }
    }

    private void OnEnable()
    {
        if (_stopTimeOnEnable)
        {
            Time.timeScale = 0;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_stopTimeOnStart)
        {
            Time.timeScale = 0;
        }
    }

    public void UnStopTime()
    {
        Time.timeScale = 1;
    }
}
