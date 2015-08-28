(function () {
    "use strict";

    function getArea(a, b, h){
        var area = ((a + b) / 2) * h;
        return area;
    }

    var sides = [
        {a: 5, b: 7, h: 12},
        {a: 2, b: 1, h: 33},
        {a: 8.5, b: 4.3, h: 2.7},
        {a: 100, b: 200, h: 300},
        {a: 0.222, b: 0.333, h: 0.555}
    ];

    var i;
    var a;
    var b;
    var h;
    var area;

    for(i =0; i < sides.length; i++){
        a = sides[i].a;
        b = sides[i].b;
        h = sides[i].h;
        area = getArea(a,b,h);

        console.log("Trapezoid\'s area is: " + area);
    }
}());