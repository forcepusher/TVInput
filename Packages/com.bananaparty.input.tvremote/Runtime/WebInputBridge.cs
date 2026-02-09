using AOT;
using System;
using System.Runtime.InteropServices;

namespace BananaParty.Input.TVRemote
{
    public static class WebInputBridge
    {
        public static void RegisterButton(WebInputDeviceType webInputDeviceType, int webKeyCode)
        {
            WebInputBridgeRegisterButton((int)webInputDeviceType, webKeyCode);
        }

        [DllImport("__Internal")]
        private static extern void WebInputBridgeRegisterButton(int webInputDeviceType, int webKeyCode);

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
