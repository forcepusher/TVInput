const tvInputLibrary = {

  // Class definition.

  $tvInput: {
    keyInitialize: function (keyIndex, inputSource) {
        document.addEventListener('keydown', function (event) {
            
            event.preventDefault();
        });

        document.addEventListener('keyup', function (event) {

            event.preventDefault();
        });
    },

    getKeyIsHeld: function (keyIndex, inputSource) {
      return true;
    },
  },

  // External C# calls.

  KeyInitialize: function (keyIndex, inputSource) {
    tvInput.keyInitialize();
  },

  GetKeyIsHeld: function (keyIndex, inputSource) {
    return tvInput.getKeyIsHeld();
  },
}

autoAddDeps(tvInputLibrary, '$tvInput');
mergeInto(LibraryManager.library, tvInputLibrary);