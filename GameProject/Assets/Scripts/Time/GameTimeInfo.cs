using UnityEngine;

[System.Serializable]
public class GameTimeInfo
{
    [Range(1f, 240f)]
    public float MonthLengthInMinutes = 10f;    // How long a month is in real world minutes
    public int DaysToTheMonth = 30;             // How many days there are in a month
    public int HoursToTheDay = 24;              // How many hours there are in a day
    public int MinutesToTheHour = 60;           // How many minutes there are in an hour
    public int SecondsToTheMinute = 60;         // How many seconds there are in a minute

    [HideInInspector]
    public float MonthLenght;                  // Month length in seconds
    [HideInInspector]
    public float DayLength;                    // Day length in seconds
    [HideInInspector]
    public float HourLength;                   // Hour length in seconds
    [HideInInspector]
    public float MinuteLength;                 // Minute length in seconds
    [HideInInspector]
    public float SecondLength;                 // Seconds length in seconds

    [HideInInspector]
    public float SpeedFactor;

    public void CalculateTimeLengths()
    {
        MonthLenght = MonthLengthInMinutes * 60 / SpeedFactor;    // Get month length in seconds
        DayLength = MonthLenght / DaysToTheMonth;
        HourLength = DayLength / HoursToTheDay;
        MinuteLength = HourLength / MinutesToTheHour;
        SecondLength = MinuteLength / SecondsToTheMinute;
    }
}
