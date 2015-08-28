var site = (function () {
    'use strict';

    function isMozilla() {
        var browser = window.navigator.appCodeName;

        if (browser === 'Mozilla') {
            alert('Yes');
        } else {
            alert('No');
        }
    }

    return {
        isMozilla: isMozilla
    }
}());
