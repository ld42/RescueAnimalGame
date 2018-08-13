using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public static TimeManager instance;

    public GameTimeInfo TimeSettings;

    [HideInInspector]
    public GameTime CurrentTime;

    private float levelTimer;
    private bool updateTimer;

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
        TimeSettings.SpeedFactor = 1f;
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
        TimeSettings.SpeedFactor = 1;
        CalculateTimeLengths();
        updateTimer = true;
    }

    public void ChangeSpeed(float factor)
    {
        TimeSettings.SpeedFactor = factor;
        CalculateTimeLengths();
        updateTimer = true;
    }

    void CalculateTime()
    {
        while (levelTimer >= TimeSettings.SecondLength)
        {
            CurrentTime.Seconds++;
            levelTimer -= TimeSettings.SecondLength;
        }
        while (CurrentTime.Seconds >= TimeSettings.SecondsToTheMinute)
        {
            CurrentTime.Minutes++;
            CurrentTime.Seconds -= TimeSettings.SecondsToTheMinute;
        }
        while (CurrentTime.Minutes >= TimeSettings.MinutesToTheHour)
        {
            CurrentTime.Hours++;
            CurrentTime.Minutes -= TimeSettings.MinutesToTheHour;
        }
        while (CurrentTime.Hours >= TimeSettings.HoursToTheDay)
        {
            CurrentTime.Days++;
            CurrentTime.Hours -= TimeSettings.HoursToTheDay;
        }
        while (CurrentTime.Days >= TimeSettings.DaysToTheMonth)
        {
            CurrentTime.Months++;
            CurrentTime.Days -= TimeSettings.DaysToTheMonth;
        }
    }

    void CalculateTimeLengths()
    {
        TimeSettings.CalculateTimeLengths();
    }

    public delegate void TimeManagerHandle();
    public static event TimeManagerHandle GameTimeUpdate;

    private static void GameTimeUpdateHasOccured()
    {
        if (GameTimeUpdate != null) GameTimeUpdate();
    }

}