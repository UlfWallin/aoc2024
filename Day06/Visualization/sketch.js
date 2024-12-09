let lines;
let guardPos;
let obstacles = [];
let visited = [];
let rows = 0;
let cols = 0;
let guardHeading = 'up';
let cellW; 
let cellH;

function preload() {
    lines = loadStrings('input.txt');
    console.log(lines);
}

function setup() {
    createCanvas(600, 600);
    //frameRate(15);

    rows = lines.length;
    cols = lines[0].length;
    cellW = width / cols;
    cellH = height / rows;

    for(let row = 0; row < rows; row++) {
        for(let col = 0; col < cols; col++) {
            if (lines[row][col] === '^') {
                guardPos = {x: col, y: row};
            }
            if (lines[row][col] === '#') {
                obstacles.push({x: col, y: row});
            }
        }
    }
}

function draw() {
    background(15, 15, 35);
    translate(cellW / 2, cellH / 2);
    for(let row = 0; row < rows; row++) {
        for(let col = 0; col < cols; col++) {
            point(col * cellW, row * cellH);
        }
    }

    noStroke();
    // Draw obstacles 
    for(let obstacle of obstacles) {
        fill(0, 204, 0);
        circle(obstacle.x * cellW, obstacle.y * cellH, cellW );
    }

    // Draw visited 
    for(let v of visited) {
        fill(255, 255, 102, 192);
        circle(v.x * cellW, v.y * cellH, cellW);
    }

    fill(255, 255, 102);
    circle(guardPos.x * cellW, guardPos.y * cellH, cellH * 2);

    const moved = moveGuard();
    if (!moved) {
        console.log(visited.length);
        noLoop();
    }
}

function moveGuard() {
    const directions = {
        up: { x: 0, y: -1 },
        right: { x: 1, y: 0 },
        down: { x: 0, y: 1 },
        left: { x: -1, y: 0 }
    };
    let newX = guardPos.x + directions[guardHeading].x;
    let newY = guardPos.y + directions[guardHeading].y;

    if (newX < 0 || newX > cols || newY < 0 || newY > rows) {
        console.log(newX, newY, cols, rows);
        return false;
    }

    if (obstacles.findIndex(p => p.x == newX && p.y == newY) >= 0) {
        console.log('obstacle! turn');
        turn();
    } else {
        if (visited.findIndex(p => p.x == guardPos.x && p.y == guardPos.y) < 0) {
            visited.push({x: guardPos.x, y: guardPos.y});
        } else {
            console.log('visited');
        }
        guardPos.x = newX;
        guardPos.y = newY;
    }
    return true;
}

function turn() {
    const turns = {'up': 'right', 'right': 'down', 'down': 'left', 'left': 'up'};
    guardHeading = turns[guardHeading];
}