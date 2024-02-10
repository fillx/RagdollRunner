namespace _4_Scripts.Core
{
    using System.Diagnostics;
    using UnityEngine;
    using Debug = UnityEngine.Debug;

    /// <summary>
    /// Utility class for colored logging in Unity.
    /// </summary>
    public static class Dbg
    {
   
        public static void Log(string message, Color style)
        {
            Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(style)}>{message}</color>");
        }

        [Conditional("ENABLE_DEBUG")]
        public static void LogWarning(string message, Color style)
        {
            Debug.LogWarning($"<color=#{ColorUtility.ToHtmlStringRGB(style)}>{message}</color>");
        }

        [Conditional("ENABLE_DEBUG")]
        public static void LogError(string message, Color style)
        {
            Debug.LogError($"<color=#{ColorUtility.ToHtmlStringRGB(style)}>{message}</color>");
        }
        
        [Conditional("ENABLE_DEBUG")]
        public static void Log(string message)
        {
            Log(message, Color.white);
        }

       
        public static void LogYellow(string message)
        {
            Log(message, Color.yellow);
        }

        [Conditional("ENABLE_DEBUG")]
        public static void LogGreen(string message)
        {
            Log(message, Color.green);
        }

        [Conditional("ENABLE_DEBUG")]
        public static void LogCyan(string message)
        {
            Log(message, Color.cyan);
        }

        [Conditional("ENABLE_DEBUG")]
        public static void LogMagenta(string message)
        {
            Log(message, Color.magenta);
        }

        [Conditional("ENABLE_DEBUG")]
        public static void LogWarning(string message)
        {
            LogWarning(message, Color.yellow);
        }

        [Conditional("ENABLE_DEBUG")]
        public static void LogError(string message)
        {
            LogError(message, Color.red);
        }
    }
}