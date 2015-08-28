var canvas = document.getElementById('canvas');
var ctx = canvas.getContext('2d'),
    width = canvas.width,
    height = canvas.height,
    state = 'RD';

function Ball(x, y, r) {
    this.x = x;
    this.y = y;
    this.r = r;
}

var ball = new Ball(50, height - 50, 10);

var reDraw = function () {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    ctx.beginPath();
    ctx.arc(ball.x, ball.y, ball.r, 0, 2 * Math.PI);
    ctx.fill();
    requestAnimationFrame(reDraw);
}

function move() {

    if (state === 'RD') {

        ball.x += 1;
        ball.y += 1;

        if (ball.y >= height) {
            ball.y -= 1;
            state = 'RU';
        }
        else if (ball.x >= width) {
            ball.x -= 1;
            state = 'LD'
        }
    }
    else if (state === 'RU') {

        ball.x += 1;
        ball.y -= 1;

        if (ball.y <= 0) {
            ball.y += 1;
            state = 'RD';
        }
        else if (ball.x >= width) {
            ball.x += 1;
            state = 'LU';
        }
    }
    else if (state === 'LU') {

        ball.x -= 1;
        ball.y -= 1;

        if (ball.y <= 0) {
            ball.y += 1;
            state = 'LD';
        }
        else if (ball.x <= 0) {
            ball.x += 1;
            state = 'RU';
        }
    }
    else if (state === 'LD') {

        ball.x -= 1;
        ball.y += 1;

        if (ball.y >= height) {
            ball.y -= 1;
            state = 'LU';
        }
        else if (ball.x <= 0) {
            ball.x += 1;
            state = 'RD';
        }
    }
}

reDraw();
setInterval(move, 10);