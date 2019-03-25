//=========================================
//Author: 洪金敏
//Create Date: 2019/03/25 10:34:39
//Description: 
//=========================================

using UnityEngine;

public class PluginBehaviour : MonoBehaviour
{
    /// <summary>
    /// 初始化成功回调
    /// </summary>
    /// <param name="isOpen"></param>
    public void InitVideoAdSuccessCallback(string isOpen)
    {
        Debug.Log(isOpen == "1" ? "初始化成功" : "关闭");
    }

    /// <summary>
    /// 初始化失败回调
    /// </summary>
    /// <param name="message"></param>
    public void InitVideoAdFailedCallback(string message)
    {
        Debug.LogFormat("初始化失败 {0} ", message);
    }

    /// <summary>
    /// 加载广告成功回调
    /// </summary>
    /// <param name="isOpen"></param>
    public void LoadVideoAdSuccessCallback(string isOpen)
    {
        Debug.Log("广告加载成功");
    }

    /// <summary>
    /// 加载广告失败回调
    /// </summary>
    /// <param name="message"></param>
    public void LoadVideoFailedCallback(string message)
    {
        Debug.LogFormat("广告加载失败 {0}", message);
    }

    /// <summary>
    /// 显示
    /// </summary>
    public void OnVideoAdShowCallback()
    {
        Debug.Log("OnVideoAdShowCallback");
    }

    /// <summary>
    /// 关闭广告回调
    /// </summary>
    public void OnVideoAdClosedCallback()
    {
        Debug.Log("OnVideoAdClosedCallback");
    }

    /// <summary>
    /// 广告播放完回调
    /// </summary>
    public void OnVideoAdFinishCallback()
    {
        Debug.Log("OnVideoAdFinishCallback");
    }

    /// <summary>
    /// 广告播放失败
    /// </summary>
    /// <param name="msg"></param>
    public void OnVideoAdFailCallback(string msg)
    {
        Debug.LogFormat("OnVideoAdFailCallback {0}", msg);
    }
}