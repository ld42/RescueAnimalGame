[System.Serializable]
public class GameTime
{
    public int Seconds;
    public int Minutes;
    public int Hours;
    public int Days;
    public int Months;

    public float TotalSeconds;

    public GameTime()
    {
        Seconds = 0;
        Minutes = 0;
        Hours = 0;
        Days = 0;
        Months = 0;

        TotalSeconds = .0f;
    }

    public override string ToString()
    {
        return string.Format("Month {0:00}, Day {1:00} {2:00}:{3:00}H",
            Months, Days, Hours, Minutes);
    }
}