const webInputBridgeLibrary = {

  // Class definition.

  $webInputBridge: {
    keyboardDeviceType: 0,
    gamepadDeviceType: 1,

    onButtonPressCallbackPtr: undefined,

    onButtonReleaseCallbackPtr: undefined,

    registeredButtons: [],

    initialize: function (onButtonPressCallbackPtr, onButtonReleaseCallbackPtr) {
      webInputBridge.onButtonPressCallbackPtr = onButtonPressCallbackPtr;
      webInputBridge.onButtonReleaseCallbackPtr = onButtonReleaseCallbackPtr;

      document.addEventListener('keydown', function (keyEvent) {
        if (webInputBridge.registeredButtons.some(registeredButton => registeredButton.webInputDeviceType === webInputBridge.keyboardDeviceType && registeredButton.webKeyCode === keyEvent.keyCode)) {
          webInputBridge.invokeButtonCallback(webInputBridge.onButtonPressCallbackPtr, webInputBridge.keyboardDeviceType, keyEvent.keyCode);
        }
      });

      document.addEventListener('keyup', function (keyEvent) {
        if (webInputBridge.registeredButtons.some(registeredButton => registeredButton.webInputDeviceType === webInputBridge.keyboardDeviceType && registeredButton.webKeyCode === keyEvent.keyCode)) {
          webInputBridge.invokeButtonCallback(webInputBridge.onButtonReleaseCallbackPtr, webInputBridge.keyboardDeviceType, keyEvent.keyCode);
        }
      });
    },

    // Yes, if you add a polling method that Unity calls regularly (e.g. from Update()), you can avoid an internal polling loop.
    // Below is a method that performs a single poll of gamepad state.
    // Call this function from C# to process gamepad input at your desired frequency.

    pollGamepadInput: function () {
      const gamepads = navigator.getGamepads ? navigator.getGamepads() : [];
      for (let i = 0; i < gamepads.length; i++) {
        const gp = gamepads[i];
        if (!gp) continue;
        for (let btn = 0; btn < gp.buttons.length; btn++) {
          const registered = webInputBridge.registeredButtons.find(rb => rb.webInputDeviceType === webInputBridge.gamepadDeviceType && rb.webKeyCode === btn);
          if (registered) {
            if (!gp.prevButtons) gp.prevButtons = [];
            const prev = gp.prevButtons[btn] || false;
            const curr = gp.buttons[btn].pressed;
            if (curr && !prev) {
              webInputBridge.invokeButtonCallback(webInputBridge.onButtonPressCallbackPtr, webInputBridge.gamepadDeviceType, btn);
            } else if (!curr && prev) {
              webInputBridge.invokeButtonCallback(webInputBridge.onButtonReleaseCallbackPtr, webInputBridge.gamepadDeviceType, btn);
            }
            gp.prevButtons[btn] = curr;
          }
        }
      }
    },

    registerButton: function (webInputDeviceType, webKeyCode) {
      webInputBridge.registeredButtons.push({ webInputDeviceType, webKeyCode });
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

autoAddDeps(webInputBridgeLibrary, '$eventBridge');
mergeInto(LibraryManager.library, webInputBridgeLibrary);
