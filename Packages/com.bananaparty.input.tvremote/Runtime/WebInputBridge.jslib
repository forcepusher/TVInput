const webInputBridgeLibrary = {

  // Class definition.

  $webInputBridge: {
    onButtonPressCallbackPtr: undefined,

    onButtonReleaseCallbackPtr: undefined,

    initialize: function (onButtonPressCallbackPtr, onButtonReleaseCallbackPtr) {
      webInputBridge.onButtonPressCallbackPtr = onButtonPressCallbackPtr;
      webInputBridge.onButtonReleaseCallbackPtr = onButtonReleaseCallbackPtr;
    },

    getKeyIsHeld: function (keyIndex, inputSource) {
      return true;
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
