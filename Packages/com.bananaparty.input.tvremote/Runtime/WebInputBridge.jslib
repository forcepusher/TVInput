const webInputBridgeLibrary = {

  // Class definition.

  $webInputBridge: {
    onButtonPressCallbackPtr: undefined,

    onButtonReleaseCallbackPtr: undefined,

    registeredButtons: [],

    initialize: function (onButtonPressCallbackPtr, onButtonReleaseCallbackPtr) {
      webInputBridge.onButtonPressCallbackPtr = onButtonPressCallbackPtr;
      webInputBridge.onButtonReleaseCallbackPtr = onButtonReleaseCallbackPtr;

      document.addEventListener('keydown', function (keyEvent) {
        if (webInputBridge.registeredButtons.some(registeredButton => registeredButton.webInputDeviceType === 0 && registeredButton.webKeyCode === keyEvent.keyCode)) {
          webInputBridge.invokeButtonCallback(webInputBridge.onButtonPressCallbackPtr, 0, keyEvent.keyCode);
        }
      });
      
      document.addEventListener('keyup', function (keyEvent) {
        if (webInputBridge.registeredButtons.some(registeredButton => registeredButton.webInputDeviceType === 0 && registeredButton.webKeyCode === keyEvent.keyCode)) {
          webInputBridge.invokeButtonCallback(webInputBridge.onButtonReleaseCallbackPtr, 0, keyEvent.keyCode);
        }
      });
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
}

autoAddDeps(webInputBridgeLibrary, '$eventBridge');
mergeInto(LibraryManager.library, webInputBridgeLibrary);
