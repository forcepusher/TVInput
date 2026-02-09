const webInputEventBridgeLibrary = {

  // Class definition.

  $eventBridge: {
    // Per-key state: key = "inputSource_keyIndex", value = { pressCount, releaseCount }
    keyStates: {},

    getOrCreateKeyState: function (keyIndex, inputSource) {
      const keyInputSourceAndIndex = inputSource + '_' + keyIndex;
      if (!this.keyStates[keyInputSourceAndIndex]) {
        this.keyStates[keyInputSourceAndIndex] = { pressCount: 0, releaseCount: 0 };
      }
      return this.keyStates[keyInputSourceAndIndex];
    },

    keyInitialize: function (keyIndex, inputSource) {
        const state = this.getOrCreateKeyState(keyIndex, inputSource);
        // keyIndex should match event.keyCode (numeric) from C#
        document.addEventListener('keydown', function (event) {
            if (event.keyCode === keyIndex) {
                state.pressCount++;
                event.preventDefault();
            }
        });

        document.addEventListener('keyup', function (event) {
            if (event.keyCode === keyIndex) {
                state.releaseCount++;
                event.preventDefault();
            }
        });
    },

    getKeyIsHeld: function (keyIndex, inputSource) {
      return true;
    },

    consumePresses: function (keyIndex, inputSource) {
      const state = this.getOrCreateKeyState(keyIndex, inputSource);
      const n = state.pressCount;
      state.pressCount = 0;
      return n;
    },

    peekPresses: function (keyIndex, inputSource) {
      return this.getOrCreateKeyState(keyIndex, inputSource).pressCount;
    },

    consumeReleases: function (keyIndex, inputSource) {
      const state = this.getOrCreateKeyState(keyIndex, inputSource);
      const n = state.releaseCount;
      state.releaseCount = 0;
      return n;
    },

    peekReleases: function (keyIndex, inputSource) {
      return this.getOrCreateKeyState(keyIndex, inputSource).releaseCount;
    },
  },

  // External C# calls.

  KeyInitialize: function (keyIndex, inputSource) {
    tvInput.keyInitialize(keyIndex, inputSource);
  },

  GetKeyIsHeld: function (keyIndex, inputSource) {
    return tvInput.getKeyIsHeld(keyIndex, inputSource);
  },

  KeyConsumePresses: function (keyIndex, inputSource) {
    return tvInput.consumePresses(keyIndex, inputSource);
  },

  KeyPeekPresses: function (keyIndex, inputSource) {
    return tvInput.peekPresses(keyIndex, inputSource);
  },

  KeyConsumeReleases: function (keyIndex, inputSource) {
    return tvInput.consumeReleases(keyIndex, inputSource);
  },

  KeyPeekReleases: function (keyIndex, inputSource) {
    return tvInput.peekReleases(keyIndex, inputSource);
  }
}

autoAddDeps(webInputEventBridgeLibrary, '$eventBridge');
mergeInto(LibraryManager.library, webInputEventBridgeLibrary);
