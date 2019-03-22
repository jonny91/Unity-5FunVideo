//
//  iOSBridgePlugin.h
//  Unity-iPhone
//
//  Created by Jonny on 2019/3/22.
//

#ifndef iOSBridgePlugin_h
#define iOSBridgePlugin_h

extern "C"
{
    void WF_Init();
    void WF_LoadVideoAd(NSString *ab);
    void WF_ShowVideoAd();
}


#endif /* iOSBridgePlugin_h */
