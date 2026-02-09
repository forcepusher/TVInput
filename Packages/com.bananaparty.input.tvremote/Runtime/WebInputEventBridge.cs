using AOT;
using System;

namespace BananaParty.Input.TVRemote
{
    public static class WebInputEventBridge
    {
        public static void RegisterButton(WebInputDeviceType webInputDeviceType, int webKeyCode)
        {

        }

        public static void RegisterButton(int webInputDeviceType, int webKeyCode)
        {

        }

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
