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
                return KeyIsHeld(_webKeyIndex, (int)_webInputSource);
            }
        }

        [DllImport("__Internal")]
        private static extern bool KeyIsHeld(int webKeyIndex, int webInputSource);

        public int ConsumePresses()
        {
            return 0;
        }

        public int PeekPresses()
        {
            return 0; 
        }

        public int ConsumeReleases()
        {
            return 0;
        }

        public int PeekReleases()
        {
            return 0;
        }
    }
}
