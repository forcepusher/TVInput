using System.Runtime.InteropServices;
using UnityEngine;

namespace BananaParty.TVInput
{
    public class Key
    {
        private readonly KeyCode _unityKeyCode;
        private readonly int _webKeyIndex;
        private readonly WebInputSource _webInputSource;

        private int _presses;
        private int _releases;

        public Key(KeyCode unityKeyCode, int webKeyIndex, WebInputSource webInputSource)
        {
            _unityKeyCode = unityKeyCode;
            _webKeyIndex = webKeyIndex;
            _webInputSource = webInputSource;
        }

        public bool IsHeld
        {
            get
            {
                if (TVRemote.IsRunningOnWeb)
                    return GetKeyIsHeld(_webKeyIndex, (int)_webInputSource);
                else
                    return Input.GetKey(_unityKeyCode);
            }
        }

        public void PollInput()
        {
            _presses += Input.GetKeyDown(_unityKeyCode) ? 1 : 0;
            _releases += Input.GetKeyUp(_unityKeyCode) ? 1 : 0;
        }

        [DllImport("__Internal")]
        private static extern bool GetKeyIsHeld(int webKeyIndex, int webInputSource);

        public int ConsumePresses(int webKeyIndex, WebInputSource webInputSource)
        {
            if (TVRemote.IsRunningOnWeb)
            {
                return KeyConsumePresses(webKeyIndex, (int)webInputSource);
            }
            else
            {
                var presses = _presses;
                _presses = 0;
                return presses;
            }
        }

        [DllImport("__Internal")]
        private static extern int KeyConsumePresses(int webKeyIndex, int webInputSource);

        public int PeekPresses(int webKeyIndex, WebInputSource webInputSource)
        {
            if (TVRemote.IsRunningOnWeb)
                return KeyPeekPresses(webKeyIndex, (int)webInputSource);
            else
                return _presses;
        }

        [DllImport("__Internal")]
        private static extern int KeyPeekPresses(int webKeyIndex, int webInputSource);

        public int ConsumeReleases(int webKeyIndex, WebInputSource webInputSource)
        {
            if (TVRemote.IsRunningOnWeb)
            {
                return KeyConsumeReleases(webKeyIndex, (int)webInputSource);
            }
            else
            {
                var releases = _releases;
                _releases = 0;
                return releases;
            }
        }

        [DllImport("__Internal")]
        private static extern int KeyConsumeReleases(int webKeyIndex, int webInputSource);

        public int PeekReleases(int webKeyIndex, WebInputSource webInputSource)
        {
            if (TVRemote.IsRunningOnWeb)
                return KeyPeekReleases(webKeyIndex, (int)webInputSource);
            else
                return _releases;
        }

        [DllImport("__Internal")]
        private static extern int KeyPeekReleases(int webKeyIndex, int webInputSource);
    }
}
