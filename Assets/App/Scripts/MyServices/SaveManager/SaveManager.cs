using Newtonsoft.Json;
using System;
using UnityEngine;

public static class SaveManager
{
    public static void Load<T>(string key, Action<T> callback)
    {
        var json = PlayerPrefs.GetString(key);

        if (string.IsNullOrEmpty(json))
            return;

        var data = JsonConvert.DeserializeObject<T>(json);

        callback?.Invoke(data);
    }
    public static T Load<T>(string key)
    {
        var json = PlayerPrefs.GetString(key);

        if (string.IsNullOrEmpty(json))
        {
            if (typeof(T).IsValueType)
            {
                return default(T);
            }
            else
            {
                return default(T);
            }
        }

        var data = JsonConvert.DeserializeObject<T>(json);
        return data;
    }

    public static void Save(string key, object data, Action callback = null)
    {
        PlayerPrefs.SetString(key, JsonConvert.SerializeObject(data));
        callback?.Invoke();
    }
}
