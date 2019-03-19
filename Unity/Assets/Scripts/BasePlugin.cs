//=========================================
//Author: 洪金敏
//Create Date: 2019/03/19 19:38:10
//Description: 
//=========================================

using UnityEngine;

public class BasePlugin
{
    public TReturnType CallAndroid<TReturnType>(string funcName, string str)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    if (string.IsNullOrEmpty(str))
                    {
                        return jo.Call<TReturnType>(funcName);
                    }
                    else
                    {
                        return jo.Call<TReturnType>(funcName, str);
                    }
                }
            }
        }

        return default(TReturnType);
    }

    public void CallAndroid(string funcName, string str)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    if (string.IsNullOrEmpty(str))
                    {
                        jo.Call(funcName);
                    }
                    else
                    {
                        jo.Call(funcName, str);
                    }
                }
            }
        }
    }
}