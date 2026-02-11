const webInputBridgeLibrary = {

  // Class definition.

  $webInputBridge: {
    keyboardDeviceType: 0,
    gamepadDeviceType: 1,

    onButtonPressCallbackPtr: undefined,

    onButtonReleaseCallbackPtr: undefined,

    registeredKeyboardButtons: {},
    registeredGamepadButtons: {},

    previousGamepadButtonState: {},

    initialize: function (onButtonPressCallbackPtr, onButtonReleaseCallbackPtr) {
      webInputBridge.onButtonPressCallbackPtr = onButtonPressCallbackPtr;
      webInputBridge.onButtonReleaseCallbackPtr = onButtonReleaseCallbackPtr;

      document.addEventListener('keydown', function (keyEvent) {
        if (webInputBridge.registeredKeyboardButtons[keyEvent.keyCode]) {
          webInputBridge.invokeButtonCallback(webInputBridge.onButtonPressCallbackPtr, webInputBridge.keyboardDeviceType, keyEvent.keyCode);
        }
      });

      document.addEventListener('keyup', function (keyEvent) {
        if (webInputBridge.registeredKeyboardButtons[keyEvent.keyCode]) {
          webInputBridge.invokeButtonCallback(webInputBridge.onButtonReleaseCallbackPtr, webInputBridge.keyboardDeviceType, keyEvent.keyCode);
        }
      });
    },

    pollGamepadInput: function () {
      const gamepads = navigator.getGamepads ? navigator.getGamepads() : [];
      for (let gamepadIndex = 0; gamepadIndex < gamepads.length; gamepadIndex++) {
        const gamepad = gamepads[gamepadIndex];
        if (!gamepad) {
          continue;
        }
        
        let previousPressed = webInputBridge.previousGamepadButtonState[gamepadIndex];
        if (!previousPressed) {
          previousPressed = webInputBridge.previousGamepadButtonState[gamepadIndex] = [];
        }

        for (let buttonIndex = 0; buttonIndex < gamepad.buttons.length; buttonIndex++) {
          if (!webInputBridge.registeredGamepadButtons[buttonIndex]) {
            continue;
          }

          const previous = previousPressed[buttonIndex] || false;
          const current = gamepad.buttons[buttonIndex].pressed;

          if (current && !previous) {
            webInputBridge.invokeButtonCallback(webInputBridge.onButtonPressCallbackPtr, webInputBridge.gamepadDeviceType, buttonIndex);
          } else if (!current && previous) {
            webInputBridge.invokeButtonCallback(webInputBridge.onButtonReleaseCallbackPtr, webInputBridge.gamepadDeviceType, buttonIndex);
          }

          previousPressed[buttonIndex] = current;
        }
      }
    },

    registerButton: function (webInputDeviceType, webKeyCode) {
      if (webInputDeviceType === webInputBridge.keyboardDeviceType) {
        webInputBridge.registeredKeyboardButtons[webKeyCode] = true;
      } else {
        webInputBridge.registeredGamepadButtons[webKeyCode] = true;
      }
    },

    invokeButtonCallback: function (callbackPtr, webInputDeviceType, webKeyCode) {
      {{{ makeDynCall('vii', 'callbackPtr') }}}(webInputDeviceType, webKeyCode);
    },
  },

  // External C# calls.

  WebInputBridgeInitialize: function (onButtonPressCallbackPtr, onButtonReleaseCallbackPtr) {
    webInputBridge.initialize(onButtonPressCallbackPtr, onButtonReleaseCallbackPtr);
  },

  WebInputBridgeRegisterButton: function (webInputDeviceType, webKeyCode) {
    webInputBridge.registerButton(webInputDeviceType, webKeyCode);
  },

  WebInputBridgePollInput: function () {
    webInputBridge.pollGamepadInput();
  },
}

autoAddDeps(webInputBridgeLibrary, '$webInputBridge');
mergeInto(LibraryManager.library, webInputBridgeLibrary);
