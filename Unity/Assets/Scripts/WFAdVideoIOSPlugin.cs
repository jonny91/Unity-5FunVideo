//=========================================
//Author: 洪金敏
//Create Date: 2019/03/22 16:03:43
//Description: 
//=========================================


using System.Runtime.InteropServices;
using UnityEngine;

public class WFAdVideoIOSPlugin : BasePlugin, IVideo
{
    [DllImport("__Internal")]
    private static extern void WF_Init();

    [DllImport("__Internal")]
    private static extern void WF_LoadVideoAd(string ab, string userId);

    [DllImport("__Internal")]
    private static extern void WF_ShowVideoAd();

    [DllImport("__Internal")]
    private static extern bool WF_ADIsReadyToPlay();

    public void Init()
    {
        WF_Init();
    }

    public void LoadVideoAd(string[] args)
    {
        string adName = args[0];
        string userId = args[1];
        WF_LoadVideoAd(adName, userId);
    }

    public void ShowVideoAd(string[] args)
    {
        WF_ShowVideoAd();
    }

    public bool ADIsReadyToPlay()
    {
        return WF_ADIsReadyToPlay();
    }
}