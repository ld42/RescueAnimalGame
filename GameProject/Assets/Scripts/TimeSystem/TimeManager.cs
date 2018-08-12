using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Range(1f, 240f)]
    public float MonthLengthInMinutes = 10f;    // How long a month is in real world minutes
    public int DaysToTheMonth = 30;             // How many days there are in a month
    public int HoursToTheDay = 24;              // How many hours there are in a day
    public int MinutesToTheHour = 60;           // How many minutes there are in an hour
    public int SecondsToTheMinute = 60;         // How many seconds there are in a minute

    private float monthLenght;                  // Month length in seconds
    private float dayLength;                    // Day length in seconds
    private float hourLength;                   // Hour length in seconds
    private float minuteLength;                 // Minute length in seconds
    private float secondLength;                 // Seconds length in seconds

    private int currentSecond = 0;
    private int currentMinute = 0;
    private int currentHour = 0;
    private int currentDay = 0;
    private int currentMonth = 0;

    private float totalTimer;
    private float levelTimer;
    private bool updateTimer;

    private void Start()
    {
        monthLenght = MonthLengthInMinutes * 60;    // Get month length in seconds
        dayLength = monthLenght / DaysToTheMonth;
        hourLength = dayLength / HoursToTheDay;
        minuteLength = hourLength / MinutesToTheHour;
        secondLength = minuteLength / SecondsToTheMinute;

        levelTimer = .0f;
        updateTimer = true;
    }

    private void Update()
    {
        if (updateTimer)
        {
            levelTimer += Time.deltaTime;
            totalTimer += Time.deltaTime;
            CalculateTime();
        }
    }

    public void PauseGame()
    {
        updateTimer = false;
    }

    public void ContinueGame()
    {
        updateTimer = true;
    }

    void CalculateTime()
    {
        while (levelTimer >= secondLength)
        {
            currentSecond++;
            levelTimer -= secondLength;
        }
        while (currentSecond >= SecondsToTheMinute)
        {
            currentMinute++;
            currentSecond -= SecondsToTheMinute;
        }
        while (currentMinute >= MinutesToTheHour)
        {
            currentHour++;
            currentMinute -= MinutesToTheHour;
        }
        while (currentHour >= HoursToTheDay)
        {
            currentDay++;
            currentHour -= HoursToTheDay;
        }
        while (currentDay >= DaysToTheMonth)
        {
            currentMonth++;
            currentDay -= DaysToTheMonth;
        }
    }

    //public delegate void TimeManagerHandle(GameTime gameTime);
    //public static event TimeManagerHandle GameTimeUpdate;

    //private static void GameTimeUpdateHasOccured(GameTime gameTime)
    //{
    //    if (GameTimeUpdate != null) GameTimeUpdate(gameTime);
    //}

}