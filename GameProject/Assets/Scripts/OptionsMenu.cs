using TMPro;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{

    public void ChangeLanguage(TMP_Text languageSelected)
    {
        string localizationFile;
        switch (languageSelected.text)
        {
            case "Spanish":
                localizationFile = "strings.es.json";
                break;
            default:
                localizationFile = "strings.en.json";
                break;
        }
        LocalizationManager.instance.LoadLocalizedText(localizationFile);
    }
}
