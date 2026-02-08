const tvInputLibrary = {

  // Class definition.

  $tvInput: {
    keyInitialize: function () {

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