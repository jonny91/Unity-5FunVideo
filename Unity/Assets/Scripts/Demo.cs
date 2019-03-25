//=========================================
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

    private void ShowHandler()
    {
        _videoPlugin.ShowVideoAd(new[] {AdsIdInput.text, "1", "adPosition 1"});
    }

    private void LoadHandler()
    {
        _videoPlugin.LoadVideoAd(new[] {"1", "广告位1"});
    }
}