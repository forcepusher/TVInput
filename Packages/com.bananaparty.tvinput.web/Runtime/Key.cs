using System.Runtime.InteropServices;
using UnityEngine;

namespace BananaParty.TVInput
{
    public class Key
    {
        private readonly KeyCode _unityKeyCode;
        private readonly int _webKeyIndex;
        private readonly WebInputSource _webInputSource;

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
                return GetKeyIsHeld(_webKeyIndex, (int)_webInputSource);
            }
        }

        [DllImport("__Internal")]
        private static extern bool GetKeyIsHeld(int webKeyIndex, int webInputSource);

        public int ConsumePresses(int webKeyIndex, WebInputSource webInputSource)
        {
            return KeyConsumePresses(webKeyIndex, (int)webInputSource);
        }

        [DllImport("__Internal")]
        private static extern int KeyConsumePresses(int webKeyIndex, int webInputSource);

        public int PeekPresses(int webKeyIndex, WebInputSource webInputSource)
        {
            return KeyPeekPresses(webKeyIndex, (int)webInputSource);
        }

        [DllImport("__Internal")]
        private static extern int KeyPeekPresses(int webKeyIndex, int webInputSource);

        public int ConsumeReleases(int webKeyIndex, WebInputSource webInputSource)
        {
            return KeyConsumeReleases(webKeyIndex, (int)webInputSource);
        }

        [DllImport("__Internal")]
        private static extern int KeyConsumeReleases(int webKeyIndex, int webInputSource);

        public int PeekReleases(int webKeyIndex, WebInputSource webInputSource)
        {
            return KeyPeekReleases(webKeyIndex, (int)webInputSource);
        }

        [DllImport("__Internal")]
        private static extern int KeyPeekReleases(int webKeyIndex, int webInputSource);
    }
}
