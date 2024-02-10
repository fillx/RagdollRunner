using System;
using System.Collections.Generic;

public static class ServiceContainer 
{
    private static Dictionary<Type, object> _Container = new Dictionary<Type, object>();

    public static T Register<T>(T obj)
    {
        _Container[typeof(T)] = obj;
        return obj;
    }

    public static T Resolve<T>()
    {
        return (T)_Container[typeof(T)];
    }
}

