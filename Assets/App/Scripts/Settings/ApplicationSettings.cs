using System;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationSettings : MonoBehaviour
{
    public Localization Localizations;
    [SerializeField] private ISetting[] _allSettings;
    [SerializeField] private GameObject[] _allSettingsObj;
    private const string KEY = "APLICATION_SETTINGS";
    private SaveSettings saveSettings = new SaveSettings();

    //public PlayMusic PlayMusics;
    public bool Musics;
    public PlaySound PlaySounds;
    public bool Sounds;
    public CustomToggle VibrationToggle;
    public bool Vibration;
    public CustomToggle ShowFpsCounterToggle;
    public bool ShowFpsCounter;


    public static ApplicationSettings instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        var d = new List<ISetting>();
        foreach (var item in _allSettingsObj)
        {
            d.Add(item.GetComponent<ISetting>());
        }
        _allSettings = d.ToArray();
        Debug.Log(_allSettings.Length);

        LoadSave();
        foreach (var setting in _allSettings)
        {
            setting.AddOnSetSetting(SaveAllSettings);
        }
    }
    void LoadSave()
    {
        if (PlayerPrefs.HasKey(KEY))
        {
            saveSettings = JsonUtility.FromJson<SaveSettings>(PlayerPrefs.GetString(KEY));

            for (int i = 0; i < _allSettings.Length; i++)
            {
                _allSettings[i].SetSetting(saveSettings._allBoolSettings[i]);
            }
        }
        else
        {
            for (int i = 0; i < _allSettings.Length; i++)
            {
                _allSettings[i].FirstLoadSettings();
            }
            SystemLanguage currentLanguage = Application.systemLanguage;
            switch (currentLanguage)
            {
                case SystemLanguage.Russian:
                    ApplicationSettings.instance.Localizations.SetLanguage(1);
                    Debug.Log("язык устройства: –усский");
                    break;
                case SystemLanguage.Ukrainian:
                    ApplicationSettings.instance.Localizations.SetLanguage(2);
                    Debug.Log("Device Language: English");
                    break;
                case SystemLanguage.English:
                    ApplicationSettings.instance.Localizations.SetLanguage(0);
                    Debug.Log("Device Language: English");
                    break;
                default:
                    ApplicationSettings.instance.Localizations.SetLanguage(0);
                    Debug.Log("язык устройства: " + currentLanguage.ToString());
                    break;
            }
        }
    }
    public void SaveAllSettings()
    {
        var listBool = new List<bool>();
        foreach (var item in _allSettings)
        {
            listBool.Add(item.GetSetting());
        }
        saveSettings._allBoolSettings = listBool.ToArray();

        foreach (var item in saveSettings._allBoolSettings)
        {
            Debug.Log(item);
        }

        PlayerPrefs.SetString(KEY, JsonUtility.ToJson(saveSettings));
        PlayerPrefs.Save();
    }
}
[Serializable]
class SaveSettings
{
    public bool[] _allBoolSettings;
}
