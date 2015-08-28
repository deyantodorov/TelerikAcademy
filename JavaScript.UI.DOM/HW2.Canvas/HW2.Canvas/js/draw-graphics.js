function drawGraphics(id) {

    function degreeToRadian(degree) {
        var radian = degree * Math.PI / 180;
        return radian;
    }

    function drawWindow(x, y, width, height) {
        ctx.beginPath();
        ctx.fillStyle = '#000';
        ctx.rect(x, y, width, height);
        ctx.fill();

        ctx.beginPath();
        ctx.strokeStyle = '#975b5b';
        ctx.moveTo(x + width / 2, y);
        ctx.lineTo(x + width / 2, y + height);
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(x, y + height / 2);
        ctx.lineTo(x + width, y + height / 2);
        ctx.stroke();

        // reset fill and stroke style
        ctx.fillStyle = '#975b5b';
        ctx.strokeStyle = 'black';
    }

    function drawHeadAndHat(x, y) {
        ctx.beginPath();
        ctx.fillStyle = '#90cad7';
        ctx.strokeStyle = '#1e505a';

        // Draw face
        ctx.save();
        ctx.scale(1, 0.9);
        ctx.arc(x + 60, y, 70, 0, (360 * Math.PI / 180));
        ctx.fill();
        ctx.stroke();
        ctx.restore();

        // Draw eyes
        ctx.beginPath();
        ctx.save();
        ctx.scale(1, 0.6);
        ctx.arc(x + 25, y + 80, 12, 0, (360 * Math.PI / 180));
        ctx.stroke();
        ctx.beginPath();
        ctx.arc(x + 75, y + 80, 12, 0, (360 * Math.PI / 180));
        ctx.stroke();
        ctx.restore();

        ctx.beginPath();
        ctx.fillStyle = '#1e505a';
        ctx.save();
        ctx.scale(0.6, 1);
        ctx.arc(x + 138, y - 32, 6, 0, (360 * Math.PI / 180));
        ctx.fill();
        ctx.beginPath();
        ctx.arc(x + 222, y - 32, 6, 0, (360 * Math.PI / 180));
        ctx.fill();
        ctx.restore();

        // Draw nose
        ctx.beginPath();
        ctx.moveTo(x + 50, y - 22);
        ctx.lineTo(x + 40, y - 20 + 20);
        ctx.lineTo(x + 50, y - 20 + 20);
        ctx.stroke();

        // Draw mouth
        ctx.beginPath();
        ctx.save();
        ctx.scale(1, 0.2);
        ctx.arc(x + 50, y + 890, 25, 0, (360 * Math.PI / 180));
        ctx.stroke();
        ctx.restore();

        // Draw hat 
        ctx.beginPath();
        ctx.fillStyle = '#396693';
        ctx.strokeStyle = '#000';
        ctx.save();
        ctx.scale(1, 0.2);
        ctx.arc(x + 55, y + 400, 100, 0, (360 * Math.PI / 180));
        ctx.stroke();
        ctx.fill();
        ctx.restore();

        ctx.beginPath();
        ctx.save();
        ctx.scale(1, 0.3);
        ctx.arc(x + 60, y - 50, 40, 0, (360 * Math.PI / 180));
        ctx.stroke();
        ctx.fill();
        ctx.restore();

        ctx.lineTo(x + 100, y - 85);
        ctx.bezierCurveTo(x + 100, y - 75, x + 10, y - 75, x + 20, y - 90);
        ctx.lineTo(x + 20, y - 153);
        ctx.fill();
        ctx.stroke();

    }

    function drawBicycle(x, y) {

        // Wheels
        ctx.beginPath();
        ctx.fillStyle = '#90cad7';
        ctx.strokeStyle = '#358193';
        ctx.arc(x, y, 60, 0, 2 * Math.PI);
        ctx.fill();
        ctx.stroke();

        ctx.beginPath();
        ctx.arc(x + 250, y, 60, 0, 2 * Math.PI);
        ctx.fill();
        ctx.stroke();

        // Bars
        ctx.beginPath();
        ctx.moveTo(x + 250, y);
        ctx.lineTo(x + 220, y - 100);
        ctx.lineTo(x + 270, y - 130);
        ctx.moveTo(x + 220, y - 100);
        ctx.lineTo(x + 160, y - 90);
        ctx.moveTo(x + 227, y - 72);
        ctx.lineTo(x + 120, y + 10);
        ctx.lineTo(x, y);
        ctx.lineTo(x + 90, y - 70);
        ctx.lineTo(x + 227, y - 72);
        ctx.moveTo(x + 118, y + 10);
        ctx.lineTo(x + 88, y - 85);
        ctx.lineTo(x + 108, y - 85);
        ctx.moveTo(x + 88, y - 85);
        ctx.lineTo(x + 68, y - 85);
        ctx.stroke();

        // Pedals
        ctx.beginPath();
        ctx.arc(x + 117, y + 8, 20, 0, 2 * Math.PI);
        ctx.moveTo(x + 106, y-7);
        ctx.lineTo(x + 90, y - 30);
        ctx.moveTo(x + 126, y+24);
        ctx.lineTo(x + 141, y + 48);
        ctx.stroke();
    }

    // 1000x600 canvas size
    var canvas = document.getElementById(id);
    var ctx = canvas.getContext('2d');

    // draw house
    var houseX = 600,
        houseY = 250,
        buildingWidth = 330,
        buildingHeight = 250,
        roofHeight = 180;

    ctx.lineWidth = '3';
    ctx.fillStyle = '#975b5b';
    ctx.strokeStyle = 'black';

    // Draw building
    ctx.moveTo(houseX, houseY);
    ctx.fillRect(houseX, houseY, buildingWidth, buildingHeight);
    ctx.strokeRect(houseX, houseY, buildingWidth, buildingHeight);

    // Draw house
    ctx.lineTo(houseX + buildingWidth / 2, houseY - roofHeight);
    ctx.lineTo(houseX + buildingWidth, houseY);
    ctx.lineTo(houseX, houseY);
    ctx.fill();
    ctx.stroke();

    // Draw chimney
    ctx.beginPath();
    ctx.moveTo(houseX + buildingWidth - 100, houseY - 40);
    ctx.lineTo(houseX + buildingWidth - 100, houseY - 140);
    ctx.lineTo(houseX + buildingWidth - 60, houseY - 140);
    ctx.lineTo(houseX + buildingWidth - 60, houseY - 40);
    ctx.fill();
    ctx.stroke();

    // Draw chimney top
    ctx.beginPath();
    ctx.save();
    ctx.scale(1, 0.3);
    ctx.arc(houseX + buildingWidth - 80, houseY + 110, 20, 0, degreeToRadian(360));
    ctx.fill();
    ctx.stroke();
    ctx.restore();

    // Draw windows
    drawWindow(houseX + 30, houseY + 30, 120, 80);
    drawWindow(houseX + 180, houseY + 30, 120, 80);
    drawWindow(houseX + 180, houseY + 140, 120, 80);

    // Draw door
    ctx.beginPath();
    ctx.moveTo(houseX + 40, houseY + buildingHeight - 2);
    ctx.lineTo(houseX + 40, houseY + buildingHeight - 82);

    var cpX1 = houseX + 40,
        cpY1 = houseY + buildingHeight - 130,
        cpX2 = houseX + 130,
        cpY2 = houseY + buildingHeight - 130,
        bX = houseX + 130,
        bY = houseY + buildingHeight - 82;

    ctx.bezierCurveTo(cpX1, cpY1, cpX2, cpY2, bX, bY);
    ctx.lineTo(houseX + 130, houseY + buildingHeight - 2);

    //ctx.moveTo(houseX + 75, 2);
    ctx.moveTo(houseX + 85, houseY + buildingHeight - 2);
    ctx.lineTo(houseX + 85, houseY + buildingHeight - 119);
    ctx.moveTo(houseX + 65, houseY + buildingHeight - 55);
    ctx.stroke();

    ctx.beginPath();
    ctx.arc(houseX + 75, houseY + buildingHeight - 45, 4, 0, degreeToRadian(360));
    ctx.stroke();

    ctx.beginPath();
    ctx.arc(houseX + 95, houseY + buildingHeight - 45, 4, 0, degreeToRadian(360));
    ctx.stroke();

    drawHeadAndHat(150, 200);

    drawBicycle(100, 450);
}

window.onload = drawGraphics('canvas');