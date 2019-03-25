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

@implementation CustomAppController

extern "C"
{
    void WF_Init(char *initChar);
    void WF_LoadVideoAd(char *ab, char *userID);
    void WF_ShowVideoAd();
    bool WF_ADIsReadyToPlay();
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
    UnitySendMessage("Plugin", "OnVideoAdFinishCallback", [ad UTF8String]);
}
// 奖励发放
- (void)adVideoReward:(NSDictionary *)rewardInfo Converted:(BOOL)converted
{
    NSLog(@"adVideoReward");
     UnitySendMessage("Plugin", "OnVideoAdFinishCallback","");
}

void WF_Init(char *initChar)
{    
    NSDictionary *param = [CustomAppController dictionaryWithJsonString:[NSString stringWithUTF8String:initChar]];
    
    [WFAdVideoSDK initAdVideoSDKWithParameters:param];
    
    NSLog(@"WF_Init");
}

void WF_LoadVideoAd(char *ab, char *userId)
{
    NSLog(@"WF_LoadVideoAd %s   %s",ab,userId);
    [WFAdVideoSDK loadVideoAd:[NSString stringWithUTF8String:ab] UserId:[NSString stringWithUTF8String:userId]];
}

void WF_ShowVideoAd()
{
    NSLog(@"WF_ShowVideoAd");
    if([WFAdVideoSDK adIsReadyToPlay])
    {
        [WFAdVideoSDK showVideoAdOnViewController:GetAppController().rootViewController];
    }
}

bool WF_ADIsReadyToPlay()
{
    return [WFAdVideoSDK adIsReadyToPlay];
}

+ (NSDictionary *) dictionaryWithJsonString:(NSString *)jsonString
{
    if (jsonString == nil) {
        return nil;
    }
    
    NSData *jsonData = [jsonString dataUsingEncoding:NSUTF8StringEncoding];
    NSError *err;
    NSDictionary *dic = [NSJSONSerialization JSONObjectWithData:jsonData
                                                        options:NSJSONReadingMutableContainers
                                                          error:&err];
    if(err)
    {
        NSLog(@"json解析失败：%@",err);
        return nil;
    }
    return dic;
}

@end
