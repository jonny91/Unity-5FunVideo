//
//  CustomAppController.mm
//  Unity-iPhone
//
//  Created by Jonny on 2019/3/22.
//

#import <Foundation/Foundation.h>
#import <WFAdVideoSDK/WFAdVideoSDK.h>
#import "UnityAppController.h"

@interface CustomAppController : UnityAppController
- (void) wfVideoInit;
- (void) wfVideoLoad;
- (void) wfVideoShow;
@end

@implementation CustomAppController

static CustomAppController * _sharedInstance = nil;

- (void)startUnity:(UIApplication *)application
{
    _sharedInstance = self;
    [super startUnity:application];
}

+ (CustomAppController *) sharedInstance
{
    return _sharedInstance;
}

- (void) wfVideoInit
{
    NSLog(@"悟饭 Video Init");
}

- (void) wfVideoLoad
{
    NSLog(@"悟饭 Video Load");
}

- (void) wfVideoShow
{
    NSLog(@"悟饭 Video Show");
}

@end
