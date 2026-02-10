using AOT;
using System;
using System.Runtime.InteropServices;
using UnityEngine.LowLevel;

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
            InjectPollInputIntoPlayerLoop();
        }

        private static class WebPollInputRunner {
            public static void PollInputUpdate()
            {
                WebInputBridgePollInput();
            }
        }

        private static void InjectPollInputIntoPlayerLoop()
        {
            PlayerLoopSystem loop = PlayerLoop.GetCurrentPlayerLoop();
            PlayerLoopSystem[] root = loop.subSystemList;
            if (root == null) return;

            int insertIndex = -1;
            for (int i = 0; i < root.Length; i++)
            {
                if (root[i].type != null && root[i].type.Name == "Update")
                {
                    insertIndex = i;
                    break;
                }
            }
            if (insertIndex < 0) return;

            var newList = new PlayerLoopSystem[root.Length + 1];
            for (int i = 0; i < insertIndex; i++)
                newList[i] = root[i];
            newList[insertIndex] = new PlayerLoopSystem
            {
                type = typeof(WebPollInputRunner),
                updateDelegate = WebPollInputRunner.PollInputUpdate
            };
            for (int i = insertIndex; i < root.Length; i++)
                newList[i + 1] = root[i];

            loop.subSystemList = newList;
            PlayerLoop.SetPlayerLoop(loop);
        }

        [DllImport("__Internal")]
        private static extern bool WebInputBridgeInitialize(Action<int, int> onButtonPressCallback, Action<int, int> onButtonReleaseCallback);

        public static void RegisterButton(WebInputDeviceType webInputDeviceType, int webKeyCode)
        {
            if (webInputDeviceType == WebInputDeviceType.Keyboard)
                WebInputBridgeRegisterKeyboardButton(webKeyCode);
            else
                WebInputBridgeRegisterGamepadButton(webKeyCode);
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
        private static extern void WebInputBridgeRegisterKeyboardButton(int webKeyCode);

        [DllImport("__Internal")]
        private static extern void WebInputBridgeRegisterGamepadButton(int webKeyCode);

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
