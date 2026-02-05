using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace KinDzaDzaGames.TVInput
{
    public class TVInputListener : MonoBehaviour
    {
        private WaitForEndOfFrame _waitForEndOfFrame = new WaitForEndOfFrame();
        private Coroutine _clearCoroutine;

        public static TVInputListener Instance;

        private static Dictionary<KeyCode, int> _keyCodeMap;

        [DllImport("__Internal")]
        private static extern void InitInputListener();
        [DllImport("__Internal")]
        private static extern int GetKeyDown(int keyCode);
        [DllImport("__Internal")]
        private static extern int GetKey(int keyCode);
        [DllImport("__Internal")]
        private static extern int GetKeyUp(int keyCode);
        [DllImport("__Internal")]
        private static extern void ClearEvents();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeKeyCodeMap();

#if UNITY_WEBGL && !UNITY_EDITOR
            InitInputListener();
#endif
        }

        private void OnEnable()
        {
            _clearCoroutine = StartCoroutine(ClearInputCoroutine());
        }

        private void OnDisable()
        {
            if (_clearCoroutine != null)
            {
                StopCoroutine(_clearCoroutine);
            }
        }

        public bool GetKey(KeyCode keyCode)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if (_keyCodeMap.TryGetValue(keyCode, out int jsKeyCode))
            {
                return GetKey(jsKeyCode) != 0;
            }
            else
            {
                return false;
            }
#else
            return Input.GetKey(keyCode);
#endif
        }

        public bool GetKeyDown(KeyCode keyCode)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if (_keyCodeMap.TryGetValue(keyCode, out int jsKeyCode))
            {
                return GetKeyDown(jsKeyCode) != 0;;
            }
            else
            {
                return false;
            }
#else
            return Input.GetKeyDown(keyCode);
#endif
        }

        public bool GetKeyUp(KeyCode keyCode)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if (_keyCodeMap.TryGetValue(keyCode, out int jsKeyCode))
            {
                return GetKeyUp(jsKeyCode) != 0;
            }
            else
            {
                return false;
            }
#else
            return Input.GetKeyUp(keyCode);
#endif
        }

        private void InitializeKeyCodeMap()
        {
            _keyCodeMap = new Dictionary<KeyCode, int> { { KeyCode.JoystickButton0, 13 } };
        }

        private IEnumerator ClearInputCoroutine()
        {
            while (true)
            {
                yield return _waitForEndOfFrame;

#if UNITY_WEBGL && !UNITY_EDITOR
                ClearEvents();
#endif
            }
        }
    }
}