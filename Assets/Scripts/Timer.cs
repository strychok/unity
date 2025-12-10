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

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            remainingTime = 0;
            running = false;

            OnTimerFinished?.Invoke();
            timerText.text = "";
        }

        //int minutes = Mathf.FloorToInt(remainingTime / 60);
        //int seconds = Mathf.FloorToInt(remainingTime % 60);
        //timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
