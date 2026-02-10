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

        public static bool HasUnreadPressEvents(WebInputDeviceType webInputDeviceType, int webKeyCode)
        {

        }

        public static bool HasUnreadReleaseEvents(WebInputDeviceType webInputDeviceType, int webKeyCode)
        {

        }

        public static PressEvent ReadPressEvents(WebInputDeviceType webInputDeviceType, int webKeyCode)
        {

        }

        public static ReleaseEvent ReadReleaseEvents(WebInputDeviceType webInputDeviceType, int webKeyCode)
        {

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
