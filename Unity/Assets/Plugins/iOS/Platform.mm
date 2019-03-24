//
//  Platform.mm
//  Unity-iPhone
//
//  Created by Jonny on 2019/3/22.
//

#import <Foundation/Foundation.h>
#import "Platform.h"
#import <WFAdVideoSDK/WFAdVideoSDK.h>

@implementation Platform

- (void) wfVideoInit
{
    NSDictionary *param = @{
                            @"appKey"         : @"5d735ac4c782401c89f8a958277ed4b5",//（NSString）
                            @"appID"          : @36,//（NSInteger）
                            @"adID"           : @0,//广告ID（NSInteger）
                            @"channelID"      : @1736,//渠道ID（NSInteger）
                            @"extension"      : @"扩展参数",//扩展参数（NSString）
                            };
    
    [WFAdVideoSDK initAdVideoSDKWithParameters:param];
    
    NSLog(@"wfVideoInit");
}

- (void) wfVideoLoad : (NSString *)ad UserId:(NSString *)userId
{
    NSLog(@"Video Load %@ %@", ad, userId);
    [WFAdVideoSDK loadVideoAd:ad UserId:userId];
}

- (void) wfVideoShow
{
    NSLog(@"wfVideoShow");
}

- (BOOL)wfADIsReadyToPlay
{
    return [WFAdVideoSDK adIsReadyToPlay];
}

static Platform * _sharedInstance = nil;

+ (Platform *) sharedInstance
{
    if(_sharedInstance == nil)
    {
        _sharedInstance = [[Platform alloc] init];
    }
    return _sharedInstance;
}

@end
