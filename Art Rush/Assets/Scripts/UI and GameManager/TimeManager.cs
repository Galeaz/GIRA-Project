using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public const int hoursDay = 24; 
    public const int minutesHour = 60;

    [SerializeField] public float dayTime; //how long the clock will go for
    float totalTime = 0;
    float currentTime = 0;

    public RectTransform minuteHand;
    public RectTransform hourHand;

    const float hourDegrees = 360 / 12, minuteDegrees = 360 / 60;

    // Update is called once per frame
    void Update()
    {
        //calculates and keeps track of time
        totalTime += Time.deltaTime;
        currentTime = totalTime % dayTime;

        //animates the clock hand sprites based on the time
        hourHand.rotation = Quaternion.Euler(0, 0, -GetHour() * hourDegrees);
        minuteHand.rotation = Quaternion.Euler(0, 0, -GetMinute() * minuteDegrees);
    }

    public float GetHour()
    {
        return currentTime * hoursDay / dayTime; //returns the hour
    }

    public float GetMinute()
    {
        return (currentTime * hoursDay * minutesHour / dayTime) / minutesHour; //returns the minute
    }
}
