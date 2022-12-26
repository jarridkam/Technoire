using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTimeDate : MonoBehaviour
{
    public string worldTime;

    private string amPM;
    public string AMPM
    {
        get { return amPM; }
        set { amPM = value; }
    }

    public float multiplier;

        [SerializeField]
    private int year;
    public int Year
    { get { return year; }
      set {year = value; }
    }

    [SerializeField]
    private int month;
    public int Month
    { get { return month; }
      set {month = value; }
    }

    [SerializeField]
    private int day;
    public int Day
    {
        get { return day; }
        set { day = value; }
    }

    private float hours;
    public float Hours
    { get {return hours; }
      set {hours = value; } }
    private float minutes;
    private float seconds;
    private int backEndTicker;
    public int BackEndTicker
    {
        get { return backEndTicker; }
        set { backEndTicker = value; }
    }

    public bool phaseLock;

    void Awake()
    {
        SetDate(23, 2, 722);
        hours = 11;
        minutes = 0;
        amPM = "PM";
    }

    
    void FixedUpdate()
    {
        
        TimeClicker();
        worldTime = SetTime(hours, minutes) + " " + amPM;

    }
    public string SetTime(float hours, float minutes)
    {
        string hour = hours.ToString();
        string minute = minutes.ToString();
        if (minutes < 10)
        {
            string currentTime = hour + ":0" + minute;
            return currentTime;
        }
        else
        {
            string currentTime = hour + ":" + minute;
            return currentTime;
        }
    }
    public string GetWorldTime()
    {
        return this.worldTime;
    }
  
    public void SetDate(int day, int month, int year)
    {
        this.day = day;
        this.month = month;
        this.year = year;
    }

    public void TimeClicker()
   {
        seconds = seconds + (Time.deltaTime * multiplier);

       if (this.seconds >= 30) // change value back to 60 after debugging.
       {
           this.minutes += 1;
           this.seconds = 0;
       }
       if (this.hours == 12 && this.minutes == 60)
       {
           hours = 0;
       }
       if (this.minutes == 60)
       {
            this.hours += 1;
            this.minutes = 0;

            if (this.month == 12 && this.day > 30)
           {
               this.year += 1;
               this.month = 1;
               this.day = 1;
           }
            if (this.hours % 12 == 0)
           {
               if (this.amPM == "PM")
               {
                   this.amPM = "AM";
                   if (this.day == 30)
                   {
                       this.month += 1;
                   }
                   this.day += 1;
                   this.backEndTicker += 1;
                   if (this.backEndTicker % 2 == 0)
                   {
                       phaseLock = false;
                   }
               }
               else
               {
                   this.amPM = "PM";
               }
           }
       }

       
   }

}
