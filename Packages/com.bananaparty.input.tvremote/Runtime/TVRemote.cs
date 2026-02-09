using UnityEngine;

namespace BananaParty.Input.TVRemote
{
    public class TVRemote
    {
        public readonly TVRemoteButton OkButton = new(KeyCode.JoystickButton0, 13, WebInputDeviceType.Keyboard);
        public readonly TVRemoteButton UpButton = new(KeyCode.JoystickButton12, 12, WebInputDeviceType.Gamepad);
        public readonly TVRemoteButton DownButton = new(KeyCode.JoystickButton13, 13, WebInputDeviceType.Gamepad);
        public readonly TVRemoteButton LeftButton = new(KeyCode.JoystickButton14, 14, WebInputDeviceType.Gamepad);
        public readonly TVRemoteButton RightButton = new(KeyCode.JoystickButton15, 15, WebInputDeviceType.Gamepad);

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
