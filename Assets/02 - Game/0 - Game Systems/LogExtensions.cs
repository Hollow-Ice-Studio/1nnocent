using UnityEngine;
using UnityEditor;

public static class LogExtensions
{
    private static string setColor(string richTextColor,string text)
    {
        return $"<color={richTextColor}>{text}</color>";
    }

    public static void LogWithColor(this Object owner, object obj, string colorname)
    {
        Debug.Log($"{setColor(colorname, obj.ToString())}");
    }
    public static void LogSystemAdded(this Object owner, string gameSystemName)
    {
        Debug.Log($"{setColor("silver","Added System:")}{setColor("lime", gameSystemName)}");
    }
}