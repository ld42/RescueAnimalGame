using UnityEngine;

public class TimerMenu : MonoBehaviour
{

    public void OnPauseButton()
    {
        TimeManager.instance.PauseGame();
    }

    public void OnResumeButton()
    {
        TimeManager.instance.ResumeGame();
    }

    public void OnSpeed1Button()
    {
        TimeManager.instance.ChangeSpeed(5);
    }

    public void OnSpeed2Button()
    {
        TimeManager.instance.ChangeSpeed(10);
    }

    public void OnSpeed3Button()
    {
        TimeManager.instance.ChangeSpeed(40);
    }
}
