using UnityEngine;

namespace KinDzaDzaGames.TVInput
{
    public static class TVWebInput
    {
        public static bool GetKeyDown(TVKeyCode keyCode)
        {
            switch (keyCode)
            {
                case TVKeyCode.OK:
                    return TVInputListener.Instance.GetKeyDown(KeyCode.JoystickButton0);
                case TVKeyCode.Up:
                    return Input.GetKeyDown(KeyCode.JoystickButton12);
                case TVKeyCode.Down:
                    return Input.GetKeyDown(KeyCode.JoystickButton13);
                case TVKeyCode.Left:
                    return Input.GetKeyDown(KeyCode.JoystickButton14);
                case TVKeyCode.Right:
                    return Input.GetKeyDown(KeyCode.JoystickButton15);
            }

            return false;
        }

        public static bool GetKey(TVKeyCode keyCode)
        {
            switch (keyCode)
            {
                case TVKeyCode.OK:
                    return TVInputListener.Instance.GetKey(KeyCode.JoystickButton0);
                case TVKeyCode.Up:
                    return Input.GetKey(KeyCode.JoystickButton12);
                case TVKeyCode.Down:
                    return Input.GetKey(KeyCode.JoystickButton13);
                case TVKeyCode.Left:
                    return Input.GetKey(KeyCode.JoystickButton14);
                case TVKeyCode.Right:
                    return Input.GetKey(KeyCode.JoystickButton15);
            }

            return false;
        }

        public static bool GetKeyUp(TVKeyCode keyCode)
        {
            switch (keyCode)
            {
                case TVKeyCode.OK:
                    return TVInputListener.Instance.GetKeyUp(KeyCode.JoystickButton0);
                case TVKeyCode.Up:
                    return Input.GetKeyUp(KeyCode.JoystickButton12);
                case TVKeyCode.Down:
                    return Input.GetKeyUp(KeyCode.JoystickButton13);
                case TVKeyCode.Left:
                    return Input.GetKeyUp(KeyCode.JoystickButton14);
                case TVKeyCode.Right:
                    return Input.GetKeyUp(KeyCode.JoystickButton15);
            }

            return false;
        }
    }
}
