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
    void WF_LoadVideoAd(char *ab, char *userID);
    void WF_ShowVideoAd();
    bool WF_ADIsReadyToPlay();
}


#endif /* iOSBridgePlugin_h */
