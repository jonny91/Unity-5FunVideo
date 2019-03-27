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
    private static extern void WF_Init(string initStr);

    [DllImport("__Internal")]
    private static extern void WF_LoadVideoAd(string ad, string userId);

    [DllImport("__Internal")]
    private static extern void WF_ShowVideoAd();

    [DllImport("__Internal")]
    private static extern bool WF_ADIsReadyToPlay();

    public void Init()
    {
//        @"appKey"         : @"5d735ac4c782401c89f8a958277ed4b5",//（NSString）
//        @"appID"          : @36,//（NSInteger）
//        @"adID"           : @0,//广告ID（NSInteger）
//        @"channelID"      : @1736,//渠道ID（NSInteger）
//        @"extension"      : @"扩展参数",//扩展参数（NSString）
        string json =
            "{\"appkey\":\"5d735ac4c782401c89f8a958277ed4b5\",\"appID\":36,\"adID\":0,\"channelID\":1736,\"extension\":\"扩展参数\"}";
        WF_Init(json);
    }

    public void LoadVideoAd(string[] args)
    {
        string oUid = args[0];
        string adPosition = args[1];
        string adName = args[2];
        WF_LoadVideoAd(adPosition, oUid);
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