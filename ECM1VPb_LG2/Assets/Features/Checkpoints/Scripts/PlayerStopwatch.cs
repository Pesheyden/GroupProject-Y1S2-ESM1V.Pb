using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStopwatch : MonoBehaviour
{
    public TextMeshProUGUI StopwatchTextField;
    public TextMeshProUGUI LastCheckpointTextField;
    public PlayerStopwatch OtherPlayerStopWatch;
    public Color FasterColor;
    public Color SlowerColor;

    [Tooltip("Time elapsed since start or last checkpoint")][Space(10)]
    public float ElapsedTime;

    [Tooltip("This list stores all the timers for the checkpoints")]
    public List<float> CheckpointsTimers = new List<float>();

    public int PlayerId;


    private void Update()
    {
        ElapsedTime += Time.deltaTime;
        DisplayMainStopwatch();
    }

    public void DisplayMainStopwatch()
    {
        // if player 1 or 2
        int Minutes = Mathf.FloorToInt(ElapsedTime / 60);
        int Seconds = Mathf.FloorToInt(ElapsedTime % 60);
        StopwatchTextField.text = string.Format("{0:00}:{1:00}", Minutes, Seconds);
    }

    public void UpdateStopwatch()
    {
        int Minutes = Mathf.FloorToInt(ElapsedTime / 60);
        int Seconds = Mathf.FloorToInt(ElapsedTime % 60);
        
        LastCheckpointTextField.text = string.Format("{0:00}:{1:00}", Minutes, Seconds);

        CheckpointsListHandler();
        ResetStopwatch();
    }

    public void ResetStopwatch()
    {
        ElapsedTime = 0;
    }

    public void CheckpointsListHandler()
    {
        CheckpointsTimers.Add(ElapsedTime);
        CompareCheckpoints(CheckpointsTimers, OtherPlayerStopWatch.CheckpointsTimers);
    }
    public void CompareCheckpoints(List<float> currentPlayerTimes, List<float> otherPlayerTimes)
    {
        int checkpointIndex = Mathf.Min(currentPlayerTimes.Count, otherPlayerTimes.Count) - 1;

        if (checkpointIndex >= 0)
        {
            float currentPlayerTime = currentPlayerTimes[checkpointIndex];
            float otherPlayerTime = otherPlayerTimes[checkpointIndex];
            float difference = currentPlayerTime - otherPlayerTime;

            LastCheckpointTextField.color = difference < 0f ? FasterColor : SlowerColor;
        }
    }
}
