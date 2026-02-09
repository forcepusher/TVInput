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

        //private int _pressCount;
        //private int _releaseCount;

        public bool IsHeld { get; private set; }

        public TVRemoteButton(WebInputDeviceType webInputDeviceType, int webKeyCode, KeyCode unityKeyCode)
        {
            _unityKeyCode = unityKeyCode;
            _webKeyCode = webKeyCode;
            _webInputDeviceType = webInputDeviceType;

            if (IsRunningOnWeb)
                WebInputBridge.RegisterButton(webInputDeviceType, webKeyCode);

            //if (TVRemote.IsRunningOnWeb)
            //    KeyInitialize(webKeyIndex, (int)webInputSource);
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
            while (WebInputBridge.HasUnreadPressEventsForKey())
                PressEventHub.AddEvent(new PressEvent(Time.realtimeSinceStartup));

            while (WebInputBridge.HasUnreadReleaseEventsForKey())
                PressEventHub.AddEvent(new PressEvent(Time.realtimeSinceStartup));
        }

        //[DllImport("__Internal")]
        //private static extern bool KeyInitialize(int webKeyIndex, int webInputSource);

        //public bool IsHeld
        //{
        //    get
        //    {
        //        if (TVRemote.IsRunningOnWeb)
        //            return GetKeyIsHeld(_webKeyIndex, (int)_webInputSource);
        //        else
        //            return Input.GetKey(_unityKeyCode);
        //    }
        //}

        //public void PollInput()
        //{
        //    _pressCount += Input.GetKeyDown(_unityKeyCode) ? 1 : 0;
        //    _releaseCount += Input.GetKeyUp(_unityKeyCode) ? 1 : 0;
        //}

        //[DllImport("__Internal")]
        //private static extern bool GetKeyIsHeld(int webKeyIndex, int webInputSource);

        //public int ConsumePresses(int webKeyIndex, WebInputDevice webInputSource)
        //{
        //    if (TVRemote.IsRunningOnWeb)
        //    {
        //        return KeyConsumePresses(webKeyIndex, (int)webInputSource);
        //    }
        //    else
        //    {
        //        var presses = _pressCount;
        //        _pressCount = 0;
        //        return presses;
        //    }
        //}

        //[DllImport("__Internal")]
        //private static extern int KeyConsumePresses(int webKeyIndex, int webInputSource);

        //public int PeekPresses(int webKeyIndex, WebInputDevice webInputSource)
        //{
        //    if (TVRemote.IsRunningOnWeb)
        //        return KeyPeekPresses(webKeyIndex, (int)webInputSource);
        //    else
        //        return _pressCount;
        //}

        //[DllImport("__Internal")]
        //private static extern int KeyPeekPresses(int webKeyIndex, int webInputSource);

        //public int ConsumeReleases(int webKeyIndex, WebInputDevice webInputSource)
        //{
        //    if (TVRemote.IsRunningOnWeb)
        //    {
        //        return KeyConsumeReleases(webKeyIndex, (int)webInputSource);
        //    }
        //    else
        //    {
        //        var releases = _releaseCount;
        //        _releaseCount = 0;
        //        return releases;
        //    }
        //}

        //[DllImport("__Internal")]
        //private static extern int KeyConsumeReleases(int webKeyIndex, int webInputSource);

        //public int PeekReleases(int webKeyIndex, WebInputDevice webInputSource)
        //{
        //    if (TVRemote.IsRunningOnWeb)
        //        return KeyPeekReleases(webKeyIndex, (int)webInputSource);
        //    else
        //        return _releaseCount;
        //}

        //[DllImport("__Internal")]
        //private static extern int KeyPeekReleases(int webKeyIndex, int webInputSource);
    }
}
