const webInputBridgeLibrary = {

  // Class definition.

  $webInputBridge: {
    keyboardDeviceType: 0,
    gamepadDeviceType: 1,

    onButtonPressCallbackPtr: undefined,

    onButtonReleaseCallbackPtr: undefined,

    registeredKeyboardButtons: [],
    registeredGamepadButtons: [],

    initialize: function (onButtonPressCallbackPtr, onButtonReleaseCallbackPtr) {
      webInputBridge.onButtonPressCallbackPtr = onButtonPressCallbackPtr;
      webInputBridge.onButtonReleaseCallbackPtr = onButtonReleaseCallbackPtr;

      document.addEventListener('keydown', function (keyEvent) {
        if (webInputBridge.registeredKeyboardButtons.includes(keyEvent.keyCode)) {
          webInputBridge.invokeButtonCallback(webInputBridge.onButtonPressCallbackPtr, webInputBridge.keyboardDeviceType, keyEvent.keyCode);
        }
      });

      document.addEventListener('keyup', function (keyEvent) {
        if (webInputBridge.registeredKeyboardButtons.includes(keyEvent.keyCode)) {
          webInputBridge.invokeButtonCallback(webInputBridge.onButtonReleaseCallbackPtr, webInputBridge.keyboardDeviceType, keyEvent.keyCode);
        }
      });
    },

    pollGamepadInput: function () {
      const gamepads = navigator.getGamepads ? navigator.getGamepads() : [];
      for (let gamepadIndex = 0; gamepadIndex < gamepads.length; gamepadIndex++) {
        const gamepad = gamepads[gamepadIndex];
        if (!gamepad) continue;
        for (let buttonIndex = 0; buttonIndex < gamepad.buttons.length; buttonIndex++) {
          if (!webInputBridge.registeredGamepadButtons.includes(buttonIndex)) continue;
          if (!gamepad.previousButtons) gamepad.previousButtons = [];
          const previous = gamepad.previousButtons[buttonIndex] || false;
          const current = gamepad.buttons[buttonIndex].pressed;
          if (current && !previous) {
            webInputBridge.invokeButtonCallback(webInputBridge.onButtonPressCallbackPtr, webInputBridge.gamepadDeviceType, buttonIndex);
          } else if (!current && previous) {
            webInputBridge.invokeButtonCallback(webInputBridge.onButtonReleaseCallbackPtr, webInputBridge.gamepadDeviceType, buttonIndex);
          }
          gamepad.previousButtons[buttonIndex] = current;
        }
      }
    },

    registerKeyboardButton: function (webKeyCode) {
      webInputBridge.registeredKeyboardButtons.push(webKeyCode);
    },
    registerGamepadButton: function (webKeyCode) {
      webInputBridge.registeredGamepadButtons.push(webKeyCode);
    },

    invokeButtonCallback: function (callbackPtr, webInputDeviceType, webKeyCode) {
      {{{ makeDynCall('vii', 'callbackPtr') }}}(webInputDeviceType, webKeyCode);
    },
  },

  // External C# calls.

  WebInputBridgeInitialize: function (onButtonPressCallbackPtr, onButtonReleaseCallbackPtr) {
    webInputBridge.initialize(onButtonPressCallbackPtr, onButtonReleaseCallbackPtr);
  },

  WebInputBridgeRegisterKeyboardButton: function (webKeyCode) {
    webInputBridge.registerKeyboardButton(webKeyCode);
  },
  WebInputBridgeRegisterGamepadButton: function (webKeyCode) {
    webInputBridge.registerGamepadButton(webKeyCode);
  },

  WebInputBridgePollInput: function () {
    webInputBridge.pollGamepadInput();
  },
}

autoAddDeps(webInputBridgeLibrary, '$eventBridge');
mergeInto(LibraryManager.library, webInputBridgeLibrary);
