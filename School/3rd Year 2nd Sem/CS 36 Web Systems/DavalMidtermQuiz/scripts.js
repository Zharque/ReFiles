function reverseWords(sentence) {
  document.getElementById("results").style.display = "block"; 

  var punctuationMark; 
  lastChar = sentence[sentence.length - 1];
  if (lastChar === '.' || lastChar === '?' || lastChar === '!') {
    punctuationMark = lastChar;
    sentence = sentence.slice(0, -1);
  }

  var wordsArray = sentence.split(' ').map(word => word.toLowerCase());
  wordsArray.reverse();
  wordsArray[0] = wordsArray[0].charAt(0).toUpperCase() + wordsArray[0].slice(1);
  sentence = wordsArray.join(' '); 
  if (punctuationMark) {
    sentence += punctuationMark;
  }
  displayReverse(sentence);
}

function verifyInput(sentence){
  if (sentence === '') {
    return;
  }

  if (sentence.trim() === '') {
    return; 
  }

  reverseWords(sentence);
  return;
}

function displayReverse(sentence) {
  document.getElementById("displayResult").textContent = sentence;
}


function handleKeyPress(event) {
  if (event.key === "Enter") {
      reverseWords(document.getElementById('input1').value);
  }
}