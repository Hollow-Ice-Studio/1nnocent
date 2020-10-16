using UnityEngine;
using UnityEditor;

public static class LogExtensions
{
    private static string setColor(string richTextColor,string text)
    {
        return $"<color={richTextColor}>{text}</color>";
    }

    public static void LogSystemAdded(this GameObject owner, string gameSystemName)
    {
        Debug.Log($"{setColor("silver","Added System:")}{setColor("lime", gameSystemName)}");
    }
}