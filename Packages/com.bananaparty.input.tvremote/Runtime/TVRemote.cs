using UnityEngine;

namespace BananaParty.Input.TVRemote
{
    public class TVRemote
    {
        public readonly TVRemoteButton OkButton = new(WebInputDeviceType.Keyboard, 13, KeyCode.JoystickButton0);
        public readonly TVRemoteButton UpButton = new(WebInputDeviceType.Gamepad, 12, KeyCode.JoystickButton12);
        public readonly TVRemoteButton DownButton = new(WebInputDeviceType.Gamepad, 13, KeyCode.JoystickButton13);
        public readonly TVRemoteButton LeftButton = new(WebInputDeviceType.Gamepad, 14, KeyCode.JoystickButton14);
        public readonly TVRemoteButton RightButton = new(WebInputDeviceType.Gamepad, 15, KeyCode.JoystickButton15);

        public void PollInput()
        {
            OkButton.PollInput();
            UpButton.PollInput();
            DownButton.PollInput();
            LeftButton.PollInput();
            RightButton.PollInput();
        }
    }
}
