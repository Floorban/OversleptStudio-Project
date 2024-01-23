using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
public class ShareButton : MonoBehaviour
{
    public static ShareButton instance;

    //for android
    private bool isProcessing = false;
    public string message;


    void Awake()
    {
        MakeInstance();
    }

    //method whihc make this object instance
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //function called from a button
    public void ButtonShare()
    {
        if (!isProcessing)
        {
            StartCoroutine(ShareScreenshot());
        }
    }
    public IEnumerator ShareScreenshot()
    {
        isProcessing = true;
        // wait for graphics to render
        yield return new WaitForEndOfFrame();
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
        // create the texture
        Texture2D screenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        // put buffer into texture
        screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0);
        // apply
        screenTexture.Apply();
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
        byte[] dataToSave = screenTexture.EncodeToPNG();
        string destination = Path.Combine(Application.persistentDataPath, System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");
        File.WriteAllBytes(destination, dataToSave);
        if (!Application.isEditor)
        {
            // block to open the file and share it ------------START
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);

            intentObject.Call<AndroidJavaObject>("setType", "text/plain");
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "" + message);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "SUBJECT");

            intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

            currentActivity.Call("startActivity", intentObject);
        }
        isProcessing = false;

    }
    /*public Button shareButton;
    private bool isFocus = false;
    private bool isProcessing = false;
    public Image shareSubject;
    void Start()
    {
        shareButton.onClick.AddListener(ShareText);
    }

    void OnApplicationFocus(bool focus)
    {
        isFocus = focus;
    }

    private void ShareText()
    {

#if UNITY_ANDROID

        if (!isProcessing)
        {
            StartCoroutine(ShareTextInAnroid());
        }

#else
		Debug.Log("No sharing set up for this platform.");
#endif

    }

#if UNITY_ANDROID

    public IEnumerator ShareTextInAnroid()
    {
        var shareMessage = "Get POP IT game from this link: " + //Message text
                           "https://play.google.com/store/apps/"; //Your link

        isProcessing = true;

        if (!Application.isEditor)
        {
            //Create intent for action send
            AndroidJavaClass intentClass =
                new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject =
                new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>
                ("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            //put text and subject extra
            intentObject.Call<AndroidJavaObject>("setType", "text/plain");

            intentObject.Call<AndroidJavaObject>
                ("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), shareSubject);
            intentObject.Call<AndroidJavaObject>
                ("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), shareMessage);

            //call createChooser method of activity class
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

            AndroidJavaObject currentActivity =
                unity.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject chooser =
                intentClass.CallStatic<AndroidJavaObject>
                ("createChooser", intentObject, "Share your high score");
            currentActivity.Call("startActivity", chooser);
        }

        yield return new WaitUntil(() => isFocus);
        isProcessing = false;
    }

#endif
    public void ShareScreen()
    {
        ScreenCapture.CaptureScreenshot("screenshot.png");    
    }*/
}
