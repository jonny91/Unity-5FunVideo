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
        var o = new LoadVideoAdArgs {adPosition = int.Parse(args[0]), positionName = args[1]};
        var jsonArg = JsonUtility.ToJson(o);
        CallAndroid("loadVideoAd", jsonArg);
    }

    public void ShowVideoAd(string[] args)
    {
        var o = new ShowVideoAdArgs {oUid = args[0], adName = args[1], adPosition = int.Parse(args[2])};
        var jsonArg = JsonUtility.ToJson(o);
        CallAndroid("showVideoAd", jsonArg);
    }

    class LoadVideoAdArgs
    {
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