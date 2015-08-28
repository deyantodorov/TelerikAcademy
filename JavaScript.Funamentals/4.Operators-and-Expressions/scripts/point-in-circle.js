(function () {
    "use strict";

    var points;
    var i;
    var x;
    var y;
    var radius = 5;

    points = [
        {x: 0, y: 1},
        {x: -5, y: 0},
        {x: -4, y: 5},
        {x: 1.5, y: -3},
        {x: -4, y: -3.5},
        {x: 100, y: -30},
        {x: 0, y: 0},
        {x: 0.2, y: -0.8},
        {x: 0.9, y: -4.93},
        {x: 2, y: 2.655}
    ];

    function inCircle(x,y){
        var circle = (x * x) + (y * y);
        var diameter = radius * radius;

        return circle <= diameter;
    }

    for(i = 0; i < points.length; i++){
        x = points[i].x;
        y = points[i].y;

        if(inCircle(x,y)){
            console.log("True: " + "Points " + x + " and " + y + " are in circle K(0, " + radius + ")");
        } else {
            console.log("False: " + "Points " + x + " and " + y + " are not in circle K(0, " + radius + ")")
        }
    }
}());