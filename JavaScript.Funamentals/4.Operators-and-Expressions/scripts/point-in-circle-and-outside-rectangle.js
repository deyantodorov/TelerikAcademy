(function(){
    "use strict";

    var x = 1;
    var y = 2;

    var circleX = 1;
    var circleY = 1;
    var circleR = 3;

    var rectangleX = -1;
    var rectangleY = 1;
    var rectangleWidth = 6;
    var rectangleHeight = 2;

    var inRectangle = (x > rectangleX || x > rectangleWidth + rectangleX) && (y > rectangleY || y > rectangleY - rectangleHeight);
    var inCircle = ((x - circleX) * (x - circleX)) + ((y - circleY) * (y - circleY)) <= (circleR * circleR);

    /*
     * The equation of a circle is (x ? a)2 + (y ? b)2 = r2 where a and b are the coordinates of the center (a, b) and r is the radius.
     * Verify given point is in circle = (x - a) * (x - a) + (y - b) * (y - b) = r * r;
     */
    if (inRectangle && inCircle)
    {
        console.log('True. Your points are in circle and out of rectangle');
    }
    else
    {
        console.log('False. Your points are not in circle and out of rectangle');
    }
}());