(function (){
    'use strict';

    function hasProperty(obj, property) {
        if (obj.hasOwnProperty(property)) {
            return 'Propery ' + property + ' exist';
        } else {
            return 'No such property ' + property;
        }
    }

    var a = hasProperty(Number, 'arguments');
    var b = hasProperty(Number, 'asdf');

    console.log(a);
    console.log(b);
}());