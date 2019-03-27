//
//  CustomAppController.mm
//  Unity-iPhone
//
//  Created by Jonny on 2019/3/22.
//

#import <Foundation/Foundation.h>
#import "UnityAppController.h"
#import <WFAdVideoSDK/WFAdVideoSDK.h>

@interface CustomAppController : UnityAppController<WFAdVideoSDKDelegate>
@end

IMPL_APP_CONTROLLER_SUBCLASS (CustomAppController)

@implementation CustomAppController

extern "C"
{
    void WF_Init(char *appKey , int appID , int adID , int channelID , char *extension);
    void WF_LoadVideoAd(char *ab, char *userID);
    void WF_ShowVideoAd();
    bool WF_ADIsReadyToPlay();
}


CustomAppController *CUSTOM_APP_CONTROLLER;
- (void)startUnity:(UIApplication *)application
{
    [super startUnity:application];
    CUSTOM_APP_CONTROLLER = self;
}

// 视频广告加载成功
- (void)adVideoLoadSuccess:(NSString *)ad
{
    NSLog(@"adVideoLoadSuccess");
    UnitySendMessage("Plugin", "LoadVideoAdSuccessCallback", "1");
}
// 点击视频广告
- (void)onAdVideoClicked:(NSString *)ad
{
    NSLog(@"onAdVideoClicked");
//    UnitySendMessage("Plugin", "OnVideoAdFinishCallback", [ad UTF8String]);
}
// 奖励发放
- (void)adVideoReward:(NSDictionary *)rewardInfo Converted:(BOOL)converted
{
    NSLog(@"adVideoReward");
    UnitySendMessage("Plugin", "OnVideoAdFinishCallback","");
}

void WF_Init(char *appKey , int appID , int adID , int channelID , char *extension)
{
    [WFAdVideoSDK sharedSDKManager].isPrintLog = TRUE;
    
    NSDictionary *param = @{
                            @"appKey"         : [NSString stringWithUTF8String:appKey],//（NSString）
                            @"appID"          : [NSNumber numberWithInt:appID],//（NSInteger）
                            @"adID"           : [NSNumber numberWithInt:adID],//广告ID（NSInteger）
                            @"channelID"      : [NSNumber numberWithInt:channelID],//渠道ID（NSInteger）
                            @"extension"      : [NSString stringWithUTF8String:extension],//扩展参数（NSString）
                            };
    
    [WFAdVideoSDK sharedSDKManager].delegate = CUSTOM_APP_CONTROLLER;
    [WFAdVideoSDK initAdVideoSDKWithParameters:param];
}

void WF_LoadVideoAd(char *ad, char *userId)
{
    [WFAdVideoSDK loadVideoAd:[NSString stringWithUTF8String:ad] UserId:[NSString stringWithUTF8String:userId]];
}

void WF_ShowVideoAd()
{
    if([WFAdVideoSDK adIsReadyToPlay])
    {
        [WFAdVideoSDK showVideoAdOnViewController:GetAppController().rootViewController];
    }
}

bool WF_ADIsReadyToPlay()
{
    return [WFAdVideoSDK adIsReadyToPlay];
}
@end
