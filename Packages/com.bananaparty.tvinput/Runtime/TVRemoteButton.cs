using System.Runtime.InteropServices;
using UnityEngine;

namespace BananaParty.TVInput
{
    public class TVRemoteButton
    {
        private readonly KeyCode _unityKeyCode;
        private readonly int _webKeyIndex;
        private readonly WebInputDevice _webInputDevice;

        private readonly EventHub<PressEvent> PressEventHub = new();
        private readonly EventHub<ReleaseEvent> ReleaseEventHub = new();

        //private int _pressCount;
        //private int _releaseCount;

        public TVRemoteButton(KeyCode unityKeyCode, int webKeyIndex, WebInputDevice webInputDevice)
        {
            _unityKeyCode = unityKeyCode;
            _webKeyIndex = webKeyIndex;
            _webInputDevice = webInputDevice;

            //if (TVRemote.IsRunningOnWeb)
            //    KeyInitialize(webKeyIndex, (int)webInputSource);
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
