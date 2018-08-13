using TMPro;
using UnityEngine;

public class EventDisplayer : MonoBehaviour
{
    public TMP_Text TitleText;
    public TMP_Text MessageText;

    public void SetTitle(string title)
    {
        TitleText.text = title;
    }

    public void SetMessage(string message)
    {
        MessageText.text = message;
    }

    public void CloseMessage()
    {
        gameObject.SetActive(false);
        TimeManager.instance.ResumeGame();
    }
}
