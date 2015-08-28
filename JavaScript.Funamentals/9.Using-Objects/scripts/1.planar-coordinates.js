(function(){
    'use strict';
// Point class
    function Point(x, y) {

        this.x = x;
        this.y = y;

        Point.prototype.toString = function () {
            return "P(x = " + this.x + ", y = " + this.y + ")";
        };

        this.calcDistance = function calcDistance(point) {
            var calcX = (point.x - this.x) * (point.x - this.x);
            var calcY = (point.y - this.y) * (point.y - this.y);

            return Math.sqrt(calcX + calcY);
        };

    }

    // Line class
    function Line(p1, p2) {
        this.p1 = p1;
        this.p2 = p2;

        Line.prototype.toString = function () {
            return this.p1 + " " + this.p2;
        };
    }

    /*

     triangle inequality theorem:

     a + b > c
     b + c > a
     a + c > b

     */

    function isTriangle(line1, line2, line3) {

        var testA = line1 + line2 > line3;
        var testB = line2 + line3 > line1;
        var testC = line1 + line3 > line2;

        if (testA && testB && testC) {
            return true;
        }

        return false;
    }

    // Testing
    var p1 = new Point(0, 0);
    var p2 = new Point(1, 1);

    var p3 = new Point(2, 2);
    var p4 = new Point(3, 3);

    var p5 = new Point(5, 5);
    var p6 = new Point(6, 6);

    var p7 = new Point(8, 16);

    var l1 = new Line(p1, p2);

    console.log("p1 = " + p1);
    console.log("p2 = " + p1);
    console.log("line1 = " + l1);
    console.log("distance = " + p1.calcDistance(p2));
    console.log("distance = " + p3.calcDistance(p4));

    console.log("Form a triangle: " + isTriangle(p1.calcDistance(p2), p3.calcDistance(p4), p5.calcDistance(p6)));
    console.log("Form a triangle: " + isTriangle(p1.calcDistance(p2), p3.calcDistance(p4), p6.calcDistance(p7)));
}());