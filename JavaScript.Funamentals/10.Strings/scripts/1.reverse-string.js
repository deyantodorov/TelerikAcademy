(function(){
    'use strict';

    String.prototype.reverse = function () {
        var newStr = "";

        for (var i = this.length - 1; i >= 0; i--) {
            newStr += this[i];
        }

        return newStr;
    }

    var str = "sample";

    str = str.reverse()

    console.log(str);
}());