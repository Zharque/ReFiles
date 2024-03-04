/*
Code by: Rynz A. Daval
Course: CompSci 36
Professor: Sir Jomar Colao
Passed on: 2024.02.12
Passed at: MidtermExercises2
*/

function updateDisplay(newResult){
    var displaySpan = document.getElementById("resultDisplay");

    if (newResult === ""){
        newResult = 0;  
    }

    displaySpan.textContent = newResult.toString();
}

function updatePastDisplays(newResult){
    var displaySpan = document.getElementById("resultDisplay");
    var oldDisplay1 = document.getElementById("resultPast1");
    var oldDisplay2 = document.getElementById("resultPast2");

    var currentDisplaySpan = displaySpan.textContent;
    var currentOldDisplay1 = oldDisplay1.textContent;
    var currentOldDisplay2 = oldDisplay2.textContent;

    if (newResult === ""){
        newResult = 0;
    }

    displaySpan.textContent = newResult.toString();
    if (currentDisplaySpan !== newResult.toString()) {
        oldDisplay1.textContent = currentDisplaySpan;
        oldDisplay2.textContent = currentOldDisplay1;
    }
}

function calculatorNumber(num){
    var displaySpan = document.getElementById("resultDisplay");

    if (displaySpan.textContent === "0") {
        updateDisplay(num.toString());
      } else {
        updateDisplay(displaySpan.textContent + num.toString());
      }
}

function calculatorDecimal() {
    var displaySpan = document.getElementById("resultDisplay");
    var currentContent = displaySpan.textContent;

    var lastChar = currentContent.slice(-1);
    if (lastChar === '+' || lastChar === '–' || lastChar === '×' || lastChar === '÷') {
        displaySpan.textContent += '0.';
    } else if (!currentContent.includes('.')) {
        displaySpan.textContent += '.';
    }
}


function calculatorClear(){
    var displaySpan = document.getElementById("resultDisplay");
    updatePastDisplays(0);
}

function thereIsOperator(){
    var displaySpan = document.getElementById("resultDisplay");
    var containsOperator = /[\+\–\×\÷]/.test(displaySpan.textContent);
    return containsOperator;
}

function parseOperandsAndOperator() {
    var displaySpan = document.getElementById("resultDisplay");
    var operatorsRegex = /[\+\–\×\÷]/;
    
    var operands = displaySpan.textContent.split(operatorsRegex);
    
    var operand1 = operands[0];
    var operand1Number = parseFloat(operand1);
    var operator = displaySpan.textContent.match(operatorsRegex)[0];
    var operand2 = operands[1];
    var operand2Number = parseFloat(operand2);

    return { operand1Number, operator, operand2Number };
}

function calculatorResult() {
    var displaySpan = document.getElementById("resultDisplay");
    var resultNumber;
    var { operand1Number, operator, operand2Number } = parseOperandsAndOperator();

    if (thereIsOperator()) {
        if (!isNaN(operand2Number)) {
            if (operator === '+') {
                resultNumber = operand1Number + operand2Number;
            } else if (operator === '–') {
                resultNumber = operand1Number - operand2Number;
            } else if (operator === '×') {
                resultNumber = operand1Number * operand2Number;
            } else if (operator === '÷') {
                if (operand2Number === 0){
                    alert("Can't divide by 0");
                    resultNumber = operand1Number;
                } else {
                    resultNumber = operand1Number / operand2Number;
                }
            } else {
                alert("Invalid operator!");
                return;
            }
            resultNumber = parseFloat(resultNumber.toFixed(9));
        } else {
            resultNumber = operand1Number;
            updateDisplay(resultNumber);
            return;
        }
        updatePastDisplays(resultNumber);
    }
}

function calculatorOperator(operatorPassed) {
    var displaySpan = document.getElementById("resultDisplay");
    var currentContent = parseFloat(displaySpan.textContent);

    if (thereIsOperator()) {
        calculatorResult();
        currentContent = parseFloat(displaySpan.textContent);
        updateDisplay(currentContent + operatorPassed);
    } else {
        updateDisplay(currentContent + operatorPassed);
    }
}

function calculatorBackspace() {
    var displaySpan = document.getElementById("resultDisplay");
    var currentContent = displaySpan.textContent;

    if (currentContent !== "0") {
        var updatedContent = currentContent.slice(0, -1);
        updateDisplay(updatedContent);
    }
}

function calculatorPercent() {
    var displaySpan = document.getElementById("resultDisplay");
    var currentContent = parseFloat(displaySpan.textContent);
    updatePastDisplays(currentContent / 100);
}
