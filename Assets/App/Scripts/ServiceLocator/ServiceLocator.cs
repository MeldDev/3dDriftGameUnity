using System;
using System.Collections;
using System.Collections.Generic;

public class ServiceLocator<T> : IServiceLocator<T>
{
    private Dictionary<Type, T> _locatorMap {  get;}
    public ServiceLocator()
    {
        _locatorMap = new Dictionary<Type, T>();
    }
    public TP Get<TP>() where TP : T
    {
        var type = typeof(TP);
        if (!_locatorMap.ContainsKey(type))
        {
            throw new Exception("Error added new service");
        }
        return (TP)_locatorMap[type];
    }

    public TP Register<TP>(TP newService) where TP : T
    {
        var type = newService.GetType();

        if (_locatorMap.ContainsKey(type))
        {
            throw new Exception("Error added new service");        
        }
        _locatorMap[type] = newService;
        return newService;
    }

    public void Unregister<TP>(TP service) where TP : T
    {
        var type = service.GetType();

        if (_locatorMap.ContainsKey(type))
        {
            _locatorMap.Remove(type);
        }
    }
}
