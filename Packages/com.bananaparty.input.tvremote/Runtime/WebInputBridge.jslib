const webInputBridgeLibrary = {

  // Class definition.

  $webInputBridge: {
    onButtonPressCallbackPtr: undefined,

    onButtonReleaseCallbackPtr: undefined,

    initialize: function (onButtonPressCallbackPtr, onButtonReleaseCallbackPtr) {
      webInputBridge.onButtonPressCallbackPtr = onButtonPressCallbackPtr;
      webInputBridge.onButtonReleaseCallbackPtr = onButtonReleaseCallbackPtr;
    },

    registerButton: function (webInputDeviceType, webKeyCode) {

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
