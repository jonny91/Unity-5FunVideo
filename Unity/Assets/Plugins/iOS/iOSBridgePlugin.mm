//
//  iOSBridgePlugin.mm
//  Unity-iPhone
//
//  Created by Jonny on 2019/3/22.
//

#import <Foundation/Foundation.h>
#import "iOSBridgePlugin.h"
#import "Platform.h"

void WF_Init()
{
    [[Platform sharedInstance] wfVideoInit];
}

void WF_LoadVideoAd(char *ab, char *userId)
{
    [[Platform sharedInstance] wfVideoLoad:[NSString stringWithUTF8String:ab] UserId:[NSString stringWithUTF8String:userId]];
}

void WF_ShowVideoAd()
{
    [[Platform sharedInstance] wfVideoShow];
}

bool WF_ADIsReadyToPlay()
{
    return [[Platform sharedInstance] wfADIsReadyToPlay];
}

