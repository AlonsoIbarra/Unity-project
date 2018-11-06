using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyTimer : MonoBehaviour
{
    [HideInInspector]
    public string timerText;
    
    public float secondsCount;
//    [HideInInspector]
    private float stopTime;
    
    public float remainingTime = 0;
//    [HideInInspector]
    public bool timerEnable = false;
    private bool timerWatchEnable=false;
    private SoundManager sm;
    void Start() {
        sm = gameObject.GetComponent<SoundManager>();
    }
    void Update()
    {
//        Debug.Log(this.remainingTime);
        UpdateTimerUI();
    }
    
    //call this on update
    public void UpdateTimerUI()
    {
        if (timerWatchEnable)
        {
            secondsCount += Time.deltaTime;
            timerText = FormatTime((int) secondsCount);
        }else if (this.timerEnable)
        {
            secondsCount += Time.deltaTime;
            remainingTime = stopTime - secondsCount;
            timerText = FormatTime((int)remainingTime);
//            Debug.Log(remainingTime);
        }
        if (0 >= remainingTime)
        {
            StopTimer();
        }
    }


    public Boolean isEnable() {
        return this.timerEnable;
    }
    public void ResetMyTimer()
    {
        StopTimeWatch();
    }

    public string FormatTime(int seconds)
    {
        TimeSpan t = TimeSpan.FromSeconds(seconds);
        string result = string.Format("{0:D2}:{1:D2}",t.Minutes,t.Seconds);
        return result;
    }

    
    public void StartTimer(float stopTime)
    {
        this.stopTime = stopTime;
        this.remainingTime = stopTime;
        this.secondsCount = 0;
        this.timerEnable = true;

    }

    public void StopTimer()
    {
        this.timerEnable = false;
    }
    public void ContinueTimer()
    {
        this.timerEnable = true;
    }

    public void StopTimeWatch()
    {
        timerWatchEnable = false;
    }

    public void StartTimeWatch()
    {
        timerWatchEnable = true;
    }
}
