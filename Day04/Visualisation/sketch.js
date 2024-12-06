var lines = [];
var found = [];
var cols;
var rows;

var currentRow = 0;
var currentCol = 0;
var xmasCount = 0;

const word = "XMAS";

function preload() {
    lines = loadStrings('input.txt');
    console.log(lines);
}

function setup() {
    createCanvas(600, 600);
    rows = lines.length;
    cols = lines[0].length;
    // frameRate(15);
}

function draw() {
    noFill();
    background(225);
    const ch = height / rows;
    const cw = width / cols;
    for (let i = 0; i < rows; i++) {
        for (let j = 0; j < cols; j++) {
            stroke(0);
            // rect(j * cw, i * ch, cw, ch);
            textAlign(CENTER, CENTER);
            // text(lines[i][j], j * cw + (cw / 2), i * ch + (ch / 2) );
            
            if (i == currentRow && j == currentCol) {
                // circle(j * cw + (cw / 2), i * ch + (ch / 2), 8);
                xmasCount += checkNeighbours(j, i, word);
            }
        }
    }

    currentCol++;
    if (currentCol == cols) {
        currentCol = 0;
        currentRow++;
    }
    
    if (currentRow + 1 === rows + 1) {
        console.log("Done", xmasCount);
        noLoop();
    }

    for(let r of found) {
        noStroke();
        fill(255, 100);
        rect(r.x * cw, r.y * ch, cw, ch);
    }
}

function checkNeighbours(col, row, word) {
    const ch = height / rows;
    const cw = width / cols;
    const szWord = word.length;
    const revWord = [...word].reverse().join('');
    noFill();

    let wordCount = 0;
    // e
    if (col < cols - szWord + 1) {
        let f = [];
        let txt = lines[row].substring(col, col + szWord);
        stroke(0, 225, 0);
        for(let i = 0; i < szWord; i++) {
            rect((i + col) * cw, row * ch, cw, ch);
            f.push({x: i + col, y: row});
        }
        if (txt === word || txt === revWord) {
            found.push(...f);
            wordCount++;
        }
    }
    // se
    if (col < cols - szWord + 1 && row < rows - szWord + 1) {
        let f = [];
        stroke(0, 225, 0);
        let temp = "";
        for(let i = 0; i < szWord; i++) {
            temp += lines[row + i][col + i];
            rect((i + col) * cw, (i + row) * ch, cw, ch);
           f.push({x: i + col, y: i + row});
        }
        if (temp === word || temp === revWord) {
            found.push(...f);
            wordCount++;
        }
    }
    // s
    if (row < rows - szWord + 1) {
        let f = [];
        stroke(255, 0, 0);
        let temp = "";
        for(let i = 0; i < szWord; i++) {
            temp += lines[row + i][col];
            rect(col * cw, (i + row) * ch, cw, ch);
            f.push({x: col, y: i + row});
        }
        if (temp === word || temp === revWord) {
            found.push(...f);
            wordCount++;
        }
    }
    // ne
    if (col < cols - szWord + 1 && row < rows - szWord + 1) {
        let f = [];
        stroke(255, 0, 255);
        let temp = "";
        for(let i = szWord; i > 0; i--) {
            temp += lines[szWord + row - i][col + i - 1];
            rect((i + col - 1) * cw, (szWord + row - i) * ch, cw, ch);
            // f.push({x: col + i, y: szWord + row - i});
        }
        if (temp === word || temp === revWord) {
            found.push(...f);
            wordCount++;
        }
    }
    return wordCount;
}