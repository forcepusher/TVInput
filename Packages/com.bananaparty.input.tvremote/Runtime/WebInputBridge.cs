using AOT;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.LowLevel;

namespace BananaParty.Input.TVRemote
{
    public static class WebInputBridge
    {
        private struct InputKey
        {
            public readonly WebInputDeviceType DeviceType;
            public readonly int KeyCode;

            public InputKey(WebInputDeviceType deviceType, int keyCode)
            {
                DeviceType = deviceType;
                KeyCode = keyCode;
            }
        }

        private static readonly Dictionary<InputKey, Queue<PressEvent>> _pressEventQueues = new();
        private static readonly Dictionary<InputKey, Queue<ReleaseEvent>> _releaseEventQueues = new();

#if UNITY_WEBGL && !UNITY_EDITOR
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
#endif
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Unity InitializeOnLoadMethod")]
        private static void Initialize()
        {
            WebInputBridgeInitialize(OnButtonPress, OnButtonRelease);
            InjectPollInputIntoPlayerLoop();
        }

        private static void PollInput()
        {
            WebInputBridgePollInput();
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
                type = typeof(WebInputBridge),
                updateDelegate = PollInput
            };
            for (int i = insertIndex; i < root.Length; i++)
                newList[i + 1] = root[i];

            loop.subSystemList = newList;
            PlayerLoop.SetPlayerLoop(loop);
        }

        [DllImport("__Internal")]
        private static extern void WebInputBridgeInitialize(Action<int, int> onButtonPressCallback, Action<int, int> onButtonReleaseCallback);

        public static void RegisterButton(WebInputDeviceType webInputDeviceType, int webKeyCode)
        {
            WebInputBridgeRegisterButton((int)webInputDeviceType, webKeyCode);
        }

        public static bool HasUnreadPressEvents(WebInputDeviceType webInputDeviceType, int webKeyCode)
        {
            var key = new InputKey(webInputDeviceType, webKeyCode);
            return _pressEventQueues[key].Count > 0;
        }

        public static bool HasUnreadReleaseEvents(WebInputDeviceType webInputDeviceType, int webKeyCode)
        {
            var key = new InputKey(webInputDeviceType, webKeyCode);
            return _releaseEventQueues[key].Count > 0;
        }

        public static PressEvent ReadPressEvents(WebInputDeviceType webInputDeviceType, int webKeyCode)
        {
            var key = new InputKey(webInputDeviceType, webKeyCode);
            return _pressEventQueues[key].Dequeue();
        }

        public static ReleaseEvent ReadReleaseEvents(WebInputDeviceType webInputDeviceType, int webKeyCode)
        {
            var key = new InputKey(webInputDeviceType, webKeyCode);
            return _releaseEventQueues[key].Dequeue();
        }

        [DllImport("__Internal")]
        private static extern void WebInputBridgeRegisterButton(int webInputDeviceType, int webKeyCode);

        [DllImport("__Internal")]
        private static extern void WebInputBridgePollInput();

        [MonoPInvokeCallback(typeof(Action<int, int>))]
        private static void OnButtonPress(int webInputDeviceType, int webKeyCode)
        {
            var key = new InputKey((WebInputDeviceType)webInputDeviceType, webKeyCode);
            if (!_pressEventQueues.ContainsKey(key))
                _pressEventQueues[key] = new Queue<PressEvent>();
            _pressEventQueues[key].Enqueue(new PressEvent(Time.realtimeSinceStartup));
        }

        [MonoPInvokeCallback(typeof(Action<int, int>))]
        private static void OnButtonRelease(int webInputDeviceType, int webKeyCode)
        {
            var key = new InputKey((WebInputDeviceType)webInputDeviceType, webKeyCode);
            if (!_releaseEventQueues.ContainsKey(key))
                _releaseEventQueues[key] = new Queue<ReleaseEvent>();
            _releaseEventQueues[key].Enqueue(new ReleaseEvent(Time.realtimeSinceStartup));
        }
    }
}
