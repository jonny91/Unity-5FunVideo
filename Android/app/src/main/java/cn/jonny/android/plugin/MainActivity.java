package cn.jonny.android.plugin;

import android.os.Handler;
import android.os.Looper;
import android.support.annotation.NonNull;
import android.util.Log;

import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;
import com.wufun.pay.plug.wufunvideoadlib.VideoAdData;
import com.wufun.pay.plug.wufunvideoadlib.WufunVideoAdCenter;
import com.wufun.pay.plug.wufunvideoadlib.utils.ToastUtils;

public class MainActivity extends UnityPlayerActivity {

    private static String Tag = "WufanVideo";
    /**                                                                                                                                                                                                                                                                                                                                                             aaaqAQAAAAAQQ·爱情爱情A·AAAA
     * 初始化只需要调一次即可
     * */
    public void initVideoAd() {
        Log.d(Tag , "初始化 Video");
        VideoAdData data = new VideoAdData(getApplicationContext());

        WufunVideoAdCenter.initVideoAd(this, data, new WufunVideoAdCenter.VideoInterfaceCallback() {
            @Override
            public void onSuccess(int isOpen) {
                Log.d(Tag , "初始化 " + isOpen);
                if (isOpen == 1) {
                    ToastUtils.getInstance(getApplicationContext()).showToastSystem("初始化成功");
                } else {
                    ToastUtils.getInstance(getApplicationContext()).showToastSystem("关闭");
                }
                UnityPlayer.UnitySendMessage("Plugin","InitVideoAdSuccessCallback",isOpen + "");
            }

            @Override
            public void onFaild(String message) {
                Log.d(Tag , "初始化失败");
                ToastUtils.getInstance(getApplicationContext()).showToastSystem("初始化失败");
                UnityPlayer.UnitySendMessage("Plugin","InitVideoAdFailedCallback",message);
            }
        });
    }

    public boolean adIsReady()
    {
        return WufunVideoAdCenter.isReadyVideoAd();
    }

    public void loadVideoAd(String jsonArg) {
        LoadVideoAdArgs args = JsonMapper.getInstance().fromJson(jsonArg, LoadVideoAdArgs.class);
        loadVideoAd(args.adPosition, args.positionName);
    }

    public void showVideoAd(final String jsonArg) {
        Handler mainHandler = new Handler(Looper.getMainLooper());
        mainHandler.post(new Runnable() {
            @Override
            public void run() {
                ShowVideoAdArgs args = JsonMapper.getInstance().fromJson(jsonArg, ShowVideoAdArgs.class);
                showVideoAd(args.oUid, args.adPosition, args.adName);
            }
        });
    }

    public void loadVideoAd(int adPosition, String positionName) {
        //加载首页广告位广告
        WufunVideoAdCenter.loadVideoAd(adPosition, positionName, new WufunVideoAdCenter.VideoInterfaceCallback() {
            @Override
            public void onSuccess(int isOpen) {
                ToastUtils.getInstance(MainActivity.this).showToastSystem("广告加载完成");
                UnityPlayer.UnitySendMessage("Plugin","LoadVideoAdSuccessCallback",isOpen + "");
            }

            @Override
            public void onFaild(String message) {
                ToastUtils.getInstance(MainActivity.this).showToastSystem("error message " + message);
                UnityPlayer.UnitySendMessage("Plugin","LoadVideoFailedCallback",message);
            }

        });
    }

    public void showVideoAd(String oUid, int adPosition, String adName) {
        if (WufunVideoAdCenter.isReadyVideoAd()) {
            WufunVideoAdCenter.showVideoAd(oUid, adPosition, adName, new WufunVideoAdCenter.VideoAdShowListener() {
                @Override
                public void onVideoAdShow() {
                    Log.e("adshowMeassage", "onVideoAdShow");
                    UnityPlayer.UnitySendMessage("Plugin","OnVideoAdShowCallback","");
                }

                @Override
                public void onVideoAdClosed() {
                    Log.e("adshowMeassage", "onVideoAdClosedCallback");
                    UnityPlayer.UnitySendMessage("Plugin","OnVideoAdClosedCallback","");
                }

                @Override
                public void onVideoAdFinish() {
                    Log.e("adshowMeassage", "onVideoAdFinishCallback");
                    UnityPlayer.UnitySendMessage("Plugin","OnVideoAdFinishCallback","");
                }

                @Override
                public void onVideoAdFail(String message) {
                    Log.e("adshowMeassage", "onVideoAdFail  " + message);
                    UnityPlayer.UnitySendMessage("Plugin","OnVideoAdFailCallback",message);
                }
            });
        } else {
            ToastUtils.getInstance(MainActivity.this).showToastSystem("还未准备好");
        }
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        WufunVideoAdCenter.onRequestPermissionsResult(this, requestCode, permissions, grantResults);
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        //退出游戏时需要释放资源
        WufunVideoAdCenter.onExit(MainActivity.this);
    }
}

class LoadVideoAdArgs {
    public int adPosition;
    public String positionName;
}

class ShowVideoAdArgs {
    public String oUid;
    public int adPosition;
    public String adName;
}