using UnityEngine;

public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<T>(typeof(T).ToString());
                (_instance as SingletonScriptableObject<T>)?.OnInitialize();
            }

            return _instance;
        }
        set { _instance = value; }
    }

    // Optional overridable method for initializing the instance.
    protected virtual void OnInitialize()
    {
    }
}