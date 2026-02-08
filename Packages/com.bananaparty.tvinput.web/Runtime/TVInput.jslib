const tvInputLibrary = {

  // Class definition.

  $tvInput: {
    initializeKey: function () {

    },

    getKeyIsHeld: function () {
      return document.hidden;
    },
  },

  // External C# calls.

  KeyInitialize: function () {
    tvInputKey.initialize();
  },

  GetKeyIsHeld: function () {
    return tvInputKey.getInBackground();
  },
}

autoAddDeps(tvInputLibrary, '$tvInput');
mergeInto(LibraryManager.library, tvInputLibrary);