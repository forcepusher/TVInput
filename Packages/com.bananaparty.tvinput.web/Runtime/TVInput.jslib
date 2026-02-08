const tvInputLibrary = {

  // Class definition.

  $tvInput: {
    initialize: function () {

    },

    getInBackground: function () {
      return document.hidden;
    },
  },

  // External C# calls.

  TVInputInitialize: function () {
    tvInputKey.initialize();
  },

  GetKeyIsHeld: function () {
    return tvInputKey.getInBackground();
  },
}

autoAddDeps(tvInputLibrary, '$tvInput');
mergeInto(LibraryManager.library, tvInputLibrary);