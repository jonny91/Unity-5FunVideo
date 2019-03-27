//=========================================
//Author: 洪金敏
//Create Date: 2019/03/19 19:09:33
//Description: 
//=========================================

using UnityEngine;

public class WFAdVideoAndroidPlugin : BasePlugin, IVideo
{
    public void Init()
    {
        CallAndroid("initVideoAd", null);
    }

    public void LoadVideoAd(string[] args)
    {
        var o = new LoadVideoAdArgs {oUid = args[0], adPosition = int.Parse(args[1]), positionName = args[2]};
        var jsonArg = JsonUtility.ToJson(o);
        CallAndroid("loadVideoAd", jsonArg);
    }

    public void ShowVideoAd(string[] args)
    {
        var o = new ShowVideoAdArgs {oUid = args[0], adPosition = int.Parse(args[1]), adName = args[2]};
        var jsonArg = JsonUtility.ToJson(o);
        CallAndroid("showVideoAd", jsonArg);
    }

    public bool IsAdReady()
    {
        return CallAndroid<bool>("adIsReady",null);
    }


    class LoadVideoAdArgs
    {
        public string oUid;
        public int adPosition;
        public string positionName;
    }

    class ShowVideoAdArgs
    {
        public string oUid;
        public int adPosition;
        public string adName;
    }
}