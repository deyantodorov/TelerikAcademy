(function (){
    'use strict';

    var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, "1"];

    Array.prototype.remove = function (value) {

        var index = this.indexOf(value);

        while (index !== -1) {
            this.splice(index, 1);
            index = this.indexOf(value);
        }

        return this;
    }

    console.log(arr);
    arr.remove(1);

    console.log(arr);
}());