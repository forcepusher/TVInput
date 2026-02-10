using AOT;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BananaParty.Input.TVRemote
{
    public static class WebInputBridge
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
#endif
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Unity InitializeOnLoadMethod")]
        private static void Initialize()
        {
            WebInputBridgeInitialize(OnButtonPress, OnButtonRelease);
            PollInputLoop();
        }

        private static async void PollInputLoop()
        {
            while (true)
            {
                WebInputBridgePollInput();
                await Task.Yield();
            }
        }

        [DllImport("__Internal")]
        private static extern bool WebInputBridgeInitialize(Action<int, int> onButtonPressCallback, Action<int, int> onButtonReleaseCallback);

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

        [DllImport("__Internal")]
        private static extern void WebInputBridgePollInput();

        [MonoPInvokeCallback(typeof(Action<int, int>))]
        private static void OnButtonPress(int webInputDeviceType, int webKeyCode)
        {
            
        }

        [MonoPInvokeCallback(typeof(Action<int, int>))]
        private static void OnButtonRelease(int webInputDeviceType, int webKeyCode)
        {

        }
    }
}
