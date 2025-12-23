using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    public Action OnTimerFinished;

    bool running = false;

    public void StartTimer(float time)
    {
        StopTimer();
        remainingTime = time;
        running = true;
    }

    public void StopTimer()
    {
        running = false;
    }

    void Update()
    {
        if (!running) { return; }

        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0)
        {
            remainingTime = 0;
            running = false;
            OnTimerFinished?.Invoke();
            timerText.text = "";
            //return;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
