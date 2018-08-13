using UnityEngine;

[System.Serializable]
public class GameTime
{
    public int Seconds;
    public int Minutes;
    public int Hours;
    public int Days;
    public int Months;

    public float TotalSeconds;

    public static GameTime Zero = new GameTime();

    public GameTime()
    {
        Seconds = 0;
        Minutes = 0;
        Hours = 0;
        Days = 0;
        Months = 0;

        TotalSeconds = .0f;
    }

    public GameTime(GameTime aGameTime)
    {
        Seconds = aGameTime.Seconds;
        Minutes = aGameTime.Minutes;
        Hours = aGameTime.Hours;
        Days = aGameTime.Days;
        Months = aGameTime.Months;

        TotalSeconds = aGameTime.TotalSeconds;
    }

    public override string ToString()
    {
        return string.Format("Month {0:00}, Day {1:00} {2:00}:{3:00}H",
            Months, Days, Hours, Minutes);
    }

    public override bool Equals(object obj)
    {
        GameTime other = (GameTime)obj;
        return (this.Seconds == other.Seconds &&
            this.Minutes == other.Minutes &&
            this.Hours == other.Hours &&
            this.Days == other.Days &&
            this.Months == other.Months);
    }

    public override int GetHashCode()
    {
        var hashCode = 563308554;
        hashCode = hashCode * -1521134295 + Seconds.GetHashCode();
        hashCode = hashCode * -1521134295 + Minutes.GetHashCode();
        hashCode = hashCode * -1521134295 + Hours.GetHashCode();
        hashCode = hashCode * -1521134295 + Days.GetHashCode();
        hashCode = hashCode * -1521134295 + Months.GetHashCode();
        hashCode = hashCode * -1521134295 + TotalSeconds.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(GameTime a, GameTime b)
    {
        if (ReferenceEquals(a, null))
        {
            return ReferenceEquals(b, null);
        }

        return a.Equals(b);

    }

    public static bool operator !=(GameTime a, GameTime b)
    {
        if (ReferenceEquals(a, null))
        {
            return !ReferenceEquals(b, null);
        }

        return !a.Equals(b);
    }

    public static bool operator <=(GameTime a, GameTime b)
    {
        return a.Months < b.Months ||
            (a.Months == b.Months &&
            a.Days < b.Months) ||
            (a.Months == b.Months &&
            a.Days == b.Days &&
            a.Hours < b.Hours) ||
            (a.Months == b.Months &&
            a.Days == b.Days &&
            a.Hours == b.Hours &&
            a.Minutes < b.Minutes) ||
            (a.Months == b.Months &&
            a.Days == b.Days &&
            a.Hours == b.Hours &&
            a.Minutes == b.Minutes &&
            a.Seconds < b.Seconds) ||
            a.Equals(b);
    }

    public static bool operator >=(GameTime a, GameTime b)
    {
        return a.Months > b.Months ||
            (a.Months == b.Months &&
            a.Days > b.Months) ||
            (a.Months == b.Months &&
            a.Days == b.Days &&
            a.Hours > b.Hours) ||
            (a.Months == b.Months &&
            a.Days == b.Days &&
            a.Hours == b.Hours &&
            a.Minutes > b.Minutes) ||
            (a.Months == b.Months &&
            a.Days == b.Days &&
            a.Hours == b.Hours &&
            a.Minutes == b.Minutes &&
            a.Seconds > b.Seconds) ||
            a.Equals(b);
    }

    public static bool operator <(GameTime a, GameTime b)
    {
        return a.Months < b.Months ||
            (a.Months == b.Months &&
            a.Days < b.Months) ||
            (a.Months == b.Months &&
            a.Days == b.Days &&
            a.Hours < b.Hours) ||
            (a.Months == b.Months &&
            a.Days == b.Days &&
            a.Hours == b.Hours &&
            a.Minutes < b.Minutes) ||
            (a.Months == b.Months &&
            a.Days == b.Days &&
            a.Hours == b.Hours &&
            a.Minutes == b.Minutes &&
            a.Seconds < b.Seconds);
    }

    public static bool operator >(GameTime a, GameTime b)
    {
        return a.Months > b.Months ||
            (a.Months == b.Months &&
            a.Days > b.Months) ||
            (a.Months == b.Months &&
            a.Days == b.Days &&
            a.Hours > b.Hours) ||
            (a.Months == b.Months &&
            a.Days == b.Days &&
            a.Hours == b.Hours &&
            a.Minutes > b.Minutes) ||
            (a.Months == b.Months &&
            a.Days == b.Days &&
            a.Hours == b.Hours &&
            a.Minutes == b.Minutes &&
            a.Seconds > b.Seconds);
    }
}

public static class GameTimeExtensions
{
    public static GameTime AddSeconds(this GameTime oldTime, float seconds)
    {
        GameTime newTime = new GameTime(oldTime);
        GameTimeInfo timeSettings = TimeManager.instance.TimeSettings;
        newTime.Seconds = Mathf.FloorToInt(seconds);
        while (newTime.Seconds >= timeSettings.SecondsToTheMinute)
        {
            newTime.Minutes++;
            newTime.Seconds -= timeSettings.SecondsToTheMinute;
        }
        while (newTime.Minutes >= timeSettings.MinutesToTheHour)
        {
            newTime.Hours++;
            newTime.Minutes -= timeSettings.MinutesToTheHour;
        }
        while (newTime.Hours >= timeSettings.HoursToTheDay)
        {
            newTime.Days++;
            newTime.Hours -= timeSettings.HoursToTheDay;
        }
        while (newTime.Days >= timeSettings.DaysToTheMonth)
        {
            newTime.Months++;
            newTime.Days -= timeSettings.DaysToTheMonth;
        }
        return newTime;
    }
}