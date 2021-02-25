using UnityEngine;
using UnityEditor;

public static class LogExtensions
{
    private static bool enableLogging = true;

    private static string setColor(string richTextColor,string text)
    {
        return $"<color={richTextColor}>{text}</color>";
    }

    public static void LogWithColor(this Object owner, object obj, string colorname)
    {
        if (enableLogging)
        {
            var frame = new System.Diagnostics.StackTrace().GetFrame(1);
            //var methodname = frame.GetMethod().Name;
            var classname = frame.GetMethod().DeclaringType.Name;
            Debug.Log($"{setColor("black", classname)}: {setColor(colorname, obj.ToString())}");
        }
    }

    public static void LogSystemAdded(this Object owner, string gameSystemName)
    {
        Debug.Log($"{setColor("silver","Added System:")}{setColor("lime", gameSystemName)}");
    }
}

#region mais informações
 //https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/StyledText.html
#endregion