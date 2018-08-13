using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{

    public string key;

    private void OnEnable()
    {
        LocalizationManager.LanguageChanged += OnLanguageChanged;
        OnLanguageChanged();
    }

    private void OnDisable()
    {
        LocalizationManager.LanguageChanged -= OnLanguageChanged;
    }

    private void OnLanguageChanged()
    {
        string newText = LocalizationManager.instance.GetLocalizedValue(key);
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