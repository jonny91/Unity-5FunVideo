//
//  Platform.h
//  Unity-iPhone
//
//  Created by Jonny on 2019/3/22.
//

#import <Foundation/Foundation.h>

@interface Platform : NSObject
- (void)wfVideoInit;
- (void)wfVideoLoad : (NSString *)ad UserId:(NSString *)userId;
- (void)wfVideoShow;
- (BOOL)wfADIsReadyToPlay;
+ (Platform *) sharedInstance;
@end
