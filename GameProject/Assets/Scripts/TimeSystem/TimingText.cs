using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimingText : MonoBehaviour
{

    private void OnEnable()
    {
        TimeManager.GameTimeUpdate += OnGameTimeUpdate;
    }

    private void OnDisable()
    {
        TimeManager.GameTimeUpdate -= OnGameTimeUpdate;
    }

    private void OnGameTimeUpdate()
    {
        string newText = TimeManager.instance.CurrentTime.ToString();
        if (GetComponent<Text>() != null)
        {
            Text text = GetComponent<Text>();
            text.text = newText;
        }
        if (GetComponent<TMP_Text>() != null)
        {
            TMP_Text text = GetComponent<TMP_Text>();
            text.text = newText;
        }
    }
}
