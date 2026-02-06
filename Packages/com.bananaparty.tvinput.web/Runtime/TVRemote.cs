using UnityEngine;

namespace BananaParty.TVInput
{
    public class TVRemote
    {
        public readonly Key SubmitKey = new(13, KeyCode.JoystickButton0);
        public readonly Key LeftKey = new(13, KeyCode.JoystickButton14);
        public readonly Key RightKey = new(13, KeyCode.JoystickButton15);
        public readonly Key UpKey = new(13, KeyCode.JoystickButton12);
        public readonly Key DownKey = new(13, KeyCode.JoystickButton13);
    }
}
