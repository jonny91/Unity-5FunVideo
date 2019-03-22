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
    private static extern void WF_LoadVideoAd();

    [DllImport("__Internal")]
    private static extern void WF_ShowVideoAd();

    public void Init()
    {
        WF_Init();
    }

    public void LoadVideoAd(string[] args)
    {
        WF_LoadVideoAd();
    }

    public void ShowVideoAd(string[] args)
    {
        WF_ShowVideoAd();
    }
}