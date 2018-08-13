using UnityEngine;

class WaitForGameTimeSeconds : CustomYieldInstruction
{
    private float secondsToWait;
    private GameTime endTime;

    public override bool keepWaiting
    {
        get
        {
            return endTime > TimeManager.instance.CurrentTime;
        }
    }

    public WaitForGameTimeSeconds(float seconds)
    {
        secondsToWait = seconds;
        GameTime startTime = TimeManager.instance.CurrentTime;
        endTime = startTime.AddSeconds(secondsToWait);
    }
}
