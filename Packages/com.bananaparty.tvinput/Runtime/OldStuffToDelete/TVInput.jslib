mergeInto(LibraryManager.library, {
    InitInputListener: function () {
        window.unityKeyStates = { 13: false };
        window.unityKeyDown = { 13: false };
        window.unityKeyUp = { 13: false };

        let keysPressed = new Set();

        document.addEventListener('keydown', function (event) {
            if (keysPressed.has(event.code)) {
                return;
            }

            keysPressed.add(event.code);

            var keyCode = event.keyCode || event.which;

            window.unityKeyStates[keyCode] = true;
            window.unityKeyDown[keyCode] = true;
            event.preventDefault();
        });

        document.addEventListener('keyup', function (event) {
            keysPressed.delete(event.code);

            var keyCode = event.keyCode || event.which;

            window.unityKeyStates[keyCode] = false;
            window.unityKeyUp[keyCode] = true;
            event.preventDefault();
        });
    },

    GetKey: function (keyCode) {
        return window.unityKeyStates[keyCode] ? 1 : 0;
    },

    GetKeyDown: function (keyCode) {
        return window.unityKeyDown[keyCode] ? 1 : 0;
    },

    GetKeyUp: function (keyCode) {
        return window.unityKeyUp[keyCode] ? 1 : 0;
    },

    ClearEvents: function () {
        window.unityKeyDown = { 13: false };
        window.unityKeyUp = { 13: false };
    }
});