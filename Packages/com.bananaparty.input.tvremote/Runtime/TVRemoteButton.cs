using System.Runtime.InteropServices;
using UnityEngine;

namespace BananaParty.Input.TVRemote
{
    public class TVRemoteButton
    {
        private readonly KeyCode _unityKeyCode;
        private readonly int _webKeyCode;
        private readonly WebInputDeviceType _webInputDeviceType;

        public readonly EventHub<PressEvent> PressEventHub = new();
        public readonly EventHub<ReleaseEvent> ReleaseEventHub = new();

        public bool IsHeld { get; private set; }

        public TVRemoteButton(WebInputDeviceType webInputDeviceType, int webKeyCode, KeyCode unityKeyCode)
        {
            _unityKeyCode = unityKeyCode;
            _webKeyCode = webKeyCode;
            _webInputDeviceType = webInputDeviceType;

            if (IsRunningOnWeb)
                WebInputBridge.RegisterButton(webInputDeviceType, webKeyCode);
        }

        public static bool IsRunningOnWeb
        {
            get
            {
#if UNITY_WEBGL && !UNITY_EDITOR
                return true;
#else
                return false;
#endif
            }
        }

        public void PollInput()
        {
            while (WebInputBridge.HasUnreadPressEvents(_webInputDeviceType, _webKeyCode))
                PressEventHub.AddEvent(WebInputBridge.ReadPressEvents(_webInputDeviceType, _webKeyCode));

            while (WebInputBridge.HasUnreadReleaseEvents(_webInputDeviceType, _webKeyCode))
                ReleaseEventHub.AddEvent(WebInputBridge.ReadReleaseEvents(_webInputDeviceType, _webKeyCode));
        }
    }
}
