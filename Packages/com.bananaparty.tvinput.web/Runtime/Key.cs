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
                return true;
            }
        }
    }
}
