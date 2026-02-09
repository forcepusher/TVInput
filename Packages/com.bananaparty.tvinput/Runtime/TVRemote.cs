using UnityEngine;

namespace BananaParty.TVInput
{
    public class TVRemote
    {
        public readonly TVRemoteButton SubmitKey = new(KeyCode.JoystickButton0, 13, WebInputDevice.Keyboard);
        public readonly TVRemoteButton UpKey = new(KeyCode.JoystickButton12, 12, WebInputDevice.Gamepad);
        public readonly TVRemoteButton DownKey = new(KeyCode.JoystickButton13, 13, WebInputDevice.Gamepad);
        public readonly TVRemoteButton LeftKey = new(KeyCode.JoystickButton14, 14, WebInputDevice.Gamepad);
        public readonly TVRemoteButton RightKey = new(KeyCode.JoystickButton15, 15, WebInputDevice.Gamepad);

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

        public void Initialize()
        {

        }

        public void PollInput()
        {
            //SubmitKey.PollInput();
            //UpKey.PollInput();
            //DownKey.PollInput();
            //LeftKey.PollInput();
            //RightKey.PollInput();
        }
    }
}
