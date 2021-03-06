﻿//=========================================
//Author: 洪金敏
//Create Date: 2019/03/19 15:03:54
//Description: 
//=========================================

using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    [SerializeField]
    private InputField AdsIdInput;

    [SerializeField]
    private Button LoadBtn;

    [SerializeField]
    private Button ShowBtn;

    private const string USER_ID = "唯一用户ID";

    //不同的实现方式
    private IVideo _videoPlugin;

    private void Awake()
    {
        _videoPlugin = BasePlugin.Create();

        var plugin = new GameObject("Plugin");
        plugin.AddComponent<PluginBehaviour>();
    }

    private void Start()
    {
        _videoPlugin.Init();

        LoadBtn.OnClickAsObservable().Subscribe(_ => LoadHandler()).AddTo(this);
        ShowBtn.OnClickAsObservable().Subscribe(_ => ShowHandler()).AddTo(this);
    }

    public void ShowHandler()
    {
        var text = AdsIdInput.text;
        if (_videoPlugin.IsAdReady())
        {
            _videoPlugin.ShowVideoAd(new[] {USER_ID, text, "广告位" + text});
        }
        else
        {
            Debug.LogError("广告还没准备好");
        }
    }

    public void LoadHandler()
    {
        var text = AdsIdInput.text;
        _videoPlugin.LoadVideoAd(new[] {USER_ID, text, "广告位" + text});
    }
}