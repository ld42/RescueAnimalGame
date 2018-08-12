using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public static TimeManager instance;

    [Range(1f, 240f)]
    public float MonthLengthInMinutes = 10f;    // How long a month is in real world minutes
    public int DaysToTheMonth = 30;             // How many days there are in a month
    public int HoursToTheDay = 24;              // How many hours there are in a day
    public int MinutesToTheHour = 60;           // How many minutes there are in an hour
    public int SecondsToTheMinute = 60;         // How many seconds there are in a minute

    public GameTime CurrentTime;

    private float monthLenght;                  // Month length in seconds
    private float dayLength;                    // Day length in seconds
    private float hourLength;                   // Hour length in seconds
    private float minuteLength;                 // Minute length in seconds
    private float secondLength;                 // Seconds length in seconds

    private float levelTimer;
    private bool updateTimer;
    private float speedFactor;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        CurrentTime = new GameTime();
        speedFactor = 1f;
        levelTimer = .0f;
        updateTimer = true;
        CalculateTimeLengths();
    }

    private void Update()
    {
        if (updateTimer)
        {
            levelTimer += Time.deltaTime;
            CurrentTime.TotalSeconds += Time.deltaTime;
            CalculateTime();
            GameTimeUpdateHasOccured();
        }
    }

    public void PauseGame()
    {
        updateTimer = false;
    }

    public void ResumeGame()
    {
        speedFactor = 1;
        CalculateTimeLengths();
        updateTimer = true;
    }

    public void ChangeSpeed(float factor)
    {
        speedFactor = factor;
        CalculateTimeLengths();
        updateTimer = true;
    }

    void CalculateTime()
    {
        while (levelTimer >= secondLength)
        {
            CurrentTime.Seconds++;
            levelTimer -= secondLength;
        }
        while (CurrentTime.Seconds >= SecondsToTheMinute)
        {
            CurrentTime.Minutes++;
            CurrentTime.Seconds -= SecondsToTheMinute;
        }
        while (CurrentTime.Minutes >= MinutesToTheHour)
        {
            CurrentTime.Hours++;
            CurrentTime.Minutes -= MinutesToTheHour;
        }
        while (CurrentTime.Hours >= HoursToTheDay)
        {
            CurrentTime.Days++;
            CurrentTime.Hours -= HoursToTheDay;
        }
        while (CurrentTime.Days >= DaysToTheMonth)
        {
            CurrentTime.Months++;
            CurrentTime.Days -= DaysToTheMonth;
        }
    }

    void CalculateTimeLengths()
    {
        monthLenght = MonthLengthInMinutes * 60 / speedFactor;    // Get month length in seconds
        dayLength = monthLenght / DaysToTheMonth;
        hourLength = dayLength / HoursToTheDay;
        minuteLength = hourLength / MinutesToTheHour;
        secondLength = minuteLength / SecondsToTheMinute;
    }

    public delegate void TimeManagerHandle();
    public static event TimeManagerHandle GameTimeUpdate;

    private static void GameTimeUpdateHasOccured()
    {
        if (GameTimeUpdate != null) GameTimeUpdate();
    }

}