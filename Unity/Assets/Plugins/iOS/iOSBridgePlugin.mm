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

void WF_LoadVideoAd(NSString *ab)
{
    
}

void WF_ShowVideoAd()
{
    
}

