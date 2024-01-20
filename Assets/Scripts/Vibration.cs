using UnityEngine;

public static class Vibration
{
    private static float timer = 0f;

#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
#endif

    public static void Vibrate(long milliseconds)
    {
        if (isAndroid())
        {
            vibrator.Call("vibrate", milliseconds);

            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                timer = 0f;
                Cancel();
            }
        }else
        {
            Handheld.Vibrate();
        }
    }
    public static void Cancel()
    {
        if (isAndroid())
        {
            vibrator.Call("cancel");
        }
    }
    public static bool isAndroid()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return true;
#else
        return false;
#endif
    }
}
