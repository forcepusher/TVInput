using AOT;
using System;

namespace BananaParty.Input.TVRemote
{
    public static class WebInputEventBridge
    {
        [MonoPInvokeCallback(typeof(Action))]
        private static void OnButtonPress()
        {
            
        }

        [MonoPInvokeCallback(typeof(Action))]
        private static void OnButtonRelease(int deviceType, int keyIndex)
        {

        }
    }
}
