"use strict";

var rectangles = [
    {
        width: 3,
        height: 4
    },
    {
        width: 2.5,
        height: 3
    },
    {
        width: 5,
        height: 5
    }
];

function getArea(width, height) {
    return width * height;
}

for (var i = 0; i < rectangles.length; i++) {
    var width = rectangles[i].width;
    var height = rectangles[i].height;
    var area = getArea(width,height);

    console.log("width: " + width);
    console.log("height: " + height);
    console.log("area: " + area + "\n");
}