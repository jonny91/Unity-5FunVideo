//
//  WFAdVideoSDK.h
//  WFAdVideoSDK
//
//  Created by 冯宣超 on 2019/3/9.
//  Copyright © 2019年 冯宣超. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

NS_ASSUME_NONNULL_BEGIN

@protocol WFAdVideoSDKDelegate <NSObject>

// 视频广告加载成功
- (void)adVideoLoadSuccess:(NSString *)ad;
// 点击视频广告
- (void)onAdVideoClicked:(NSString *)ad;
// 奖励发放
- (void)adVideoReward:(NSDictionary *)rewardInfo Converted:(BOOL)converted;
@end

@interface WFAdVideoSDK : NSObject

@property (nonatomic, assign) BOOL       isPrintLog;      // 是否打印日志    YES : 打印    NO : 不打印
@property (nonatomic, copy)   NSString * adChannelName;
@property (nonatomic, copy)   NSArray  * adConfigs;
@property (nonatomic, copy)   NSString * channelId;
@property (nonatomic, copy)   NSString * gameId;
@property (nonatomic, copy)   NSString * openUid;
@property (nonatomic, copy)   NSString * adPosition;
@property (nonatomic, weak)   id<WFAdVideoSDKDelegate> delegate;
/**
 初始化SDK
 
 参数如下：
  @{
     @"appKey"         : @"悟饭申请的注册码",//（NSString）（必要）
     @"appID"          : @36,//（NSInteger）（必要）
     @"adID"           : @0,//广告ID（NSInteger）
     @"channelID"      : @1736,//渠道ID（NSInteger）（必要）
     @"extension"      : @"",//扩展参数（NSString）
   }
 
 @param parameters 获取广告信息参数并实现初始化
 */
+ (void)initAdVideoSDKWithParameters:(NSDictionary *)parameters;


/**
 创建单例对象
 
 @return 单例对象
 */
+ (instancetype)sharedSDKManager;


/**
 获取SDK版本号和编译版本号
 
 @return  版本号version和编译版本号build
 */
+ (NSString *)getSDKVersionNumberAndBuildNumber;


/**
 加载激励视频

 @param ad 广告位
 @param userId 用户ID
 */
+ (void)loadVideoAd:(NSString *)ad UserId:(NSString *)userId;


/**
 激励视频是否准备就绪

 @return YES:准备就绪可以播放     NO:没有准备就绪
 */
+ (BOOL)adIsReadyToPlay;


/**
 播放激励视频

 @param VC 展示视频的接入口
 */
+ (void)showVideoAdOnViewController:(UIViewController *)VC;
@end

NS_ASSUME_NONNULL_END
