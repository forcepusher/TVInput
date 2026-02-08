const tvInputLibrary = {

  // Class definition.

  $tvInput: {
    keyInitialize: function () {
        document.addEventListener('keydown', function (event) {
            
            event.preventDefault();
        });

        document.addEventListener('keyup', function (event) {
            
            event.preventDefault();
        });
    },

    getKeyIsHeld: function () {
      return document.hidden;
    },
  },

  // External C# calls.

  KeyInitialize: function () {
    tvInput.keyInitialize();
  },

  GetKeyIsHeld: function () {
    return tvInput.getKeyIsHeld();
  },
}

autoAddDeps(tvInputLibrary, '$tvInput');
mergeInto(LibraryManager.library, tvInputLibrary);