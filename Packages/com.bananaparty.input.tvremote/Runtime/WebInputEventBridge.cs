using AOT;
using System;

namespace BananaParty.Input.TVRemote
{
    public static class WebInputEventBridge
    {


        [MonoPInvokeCallback(typeof(Action))]
        private static void OnButtonPress(int webInputDeviceType, int webKeyCode)
        {
            
        }

        [MonoPInvokeCallback(typeof(Action))]
        private static void OnButtonRelease(int webInputDeviceType, int webKeyCode)
        {

        }
    }
}
