using System;

interface ISaveManager
{
    void Save(string key, object data, Action callback);
    void Load<T>(string key, Action<T> callback);
    T Load<T>(string key);
}
