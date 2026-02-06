using UnityEngine;

namespace BananaParty.TVInput
{
    public class TVRemote
    {
        public readonly Key SubmitKey = new(KeyCode.JoystickButton0, 13, WebInputSource.Keyboard);
        public readonly Key UpKey = new(KeyCode.JoystickButton12, 12, WebInputSource.Gamepad);
        public readonly Key DownKey = new(KeyCode.JoystickButton13, 13, WebInputSource.Gamepad);
        public readonly Key LeftKey = new(KeyCode.JoystickButton14, 14, WebInputSource.Gamepad);
        public readonly Key RightKey = new(KeyCode.JoystickButton15, 15, WebInputSource.Gamepad);
        
        
    }
}
